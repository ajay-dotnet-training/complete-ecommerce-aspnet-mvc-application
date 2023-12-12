using eMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace eMovies.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Actors.ToArray();
            return View(data);
        }
    }
}
