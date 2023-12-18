using eMovies.Data;
using eMovies.Data.Services;
using eMovies.Data.Static;
using eMovies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace eMovies.Controllers
{
        [Authorize(Roles = UserRoles.Admin)]
        public class ProducersController : Controller
        {
            private readonly IProducersService _service;

            public ProducersController(IProducersService service)
            {
                 _service = service;
            }

            [AllowAnonymous]
            [Route("GetAllProducers")]
            public async Task<IActionResult> Index()
            {
                var allProducers = await _service.GetAllAsync();
                return View(allProducers);
            }

            //GET: producers/details/1
            [AllowAnonymous]
        [Route("GetProducerDetails")]
        public async Task<IActionResult> Details(int id)
            {
                var producerDetails = await _service.GetByIdAsync(id);
                if (producerDetails == null) return View("NotFound");
                return View(producerDetails);
            }

        //GET: producers/create
        [Route("CreateProducer")]
        public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
        [Route("CreateProducer")]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName,Bio")] Producer producer)
            {
                if (!ModelState.IsValid) return View(producer);

                await _service.AddAsync(producer);
                return RedirectToAction(nameof(Index));
            }

        //GET: producers/edit/1
        [Route("EditProducer")]
        public async Task<IActionResult> Edit(int id)
            {
                var producerDetails = await _service.GetByIdAsync(id);
                if (producerDetails == null) return View("NotFound");
                return View(producerDetails);
            }

            [HttpPost]
        [Route("EditProducer")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureUrl,FullName,Bio")] Producer producer)
            {
                if (!ModelState.IsValid) return View(producer);

                if (id == producer.Id)
                {
                    await _service.UpdateAsync(id, producer);
                    return RedirectToAction(nameof(Index));
                }
                return View(producer);
            }

        //GET: producers/delete/1
        [Route("DeleteProducer")]
        public async Task<IActionResult> Delete(int id)
            {
                var producerDetails = await _service.GetByIdAsync(id);
                if (producerDetails == null) return View("NotFound");
                return View(producerDetails);
            }

            [HttpPost, ActionName("Delete")]
        [Route("DeleteProducer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var producerDetails = await _service.GetByIdAsync(id);
                if (producerDetails == null) return View("NotFound");

                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
