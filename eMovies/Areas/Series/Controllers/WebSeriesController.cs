using eMovies.Areas.WebSeriesArea.Data.Services;
using eMovies.Areas.WebSeriesArea.Data.ViewModels;
using eMovies.Data.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace eMovies.Areas.WebSeriesArea.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class WebSeriesController : Controller
    {
        private readonly IWebSeriesService _service;

        public WebSeriesController(IWebSeriesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View("~/Areas/Series/Views/WebSeries/Index.cshtml",allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Name);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        //GET: Movies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetWebSeriesByIdAsync(id);
            return View(movieDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewWebSereisDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WebSeriesVM webSeries)
        {
            if (!ModelState.IsValid)
            {
                var webSereisDropdownsData = await _service.GetNewWebSereisDropdownsValues();

                ViewBag.Cinemas = new SelectList(webSereisDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(webSereisDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(webSereisDropdownsData.Actors, "Id", "FullName");

                return View(webSeries);
            }

            await _service.AddNewWebSereiesAsync(webSeries);
            return RedirectToAction(nameof(Index));
        }


        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var webSeriesDetails = await _service.GetWebSeriesByIdAsync(id);
            if (webSeriesDetails == null) return View("NotFound");

            var response = new WebSeriesVM()
            {
                Id = webSeriesDetails.Id,
                Name = webSeriesDetails.Name,
                Description = webSeriesDetails.Description,
                Price = webSeriesDetails.Price,
                StartDate = webSeriesDetails.StartDate,
                EndDate = webSeriesDetails.EndDate,
                ImageURL = webSeriesDetails.ImageURL,
                MovieCategory = webSeriesDetails.MovieCategory,
                CinemaId = webSeriesDetails.CinemaId,
                ProducerId = webSeriesDetails.ProducerId,
                ActorIds = webSeriesDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var webSereisDropdownsData = await _service.GetNewWebSereisDropdownsValues();
            ViewBag.Cinemas = new SelectList(webSereisDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(webSereisDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(webSereisDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WebSeriesVM webSeries)
        {
            if (id != webSeries.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var webSereisDropdownsData = await _service.GetNewWebSereisDropdownsValues();

                ViewBag.Cinemas = new SelectList(webSereisDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(webSereisDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(webSereisDropdownsData.Actors, "Id", "FullName");

                return View(webSeries);
            }

            await _service.UpdateWebSereiesAsync(webSeries);
            return RedirectToAction(nameof(Index));
        }
    }
}
