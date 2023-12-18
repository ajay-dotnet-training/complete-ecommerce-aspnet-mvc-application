using eMovies.Models;

namespace eMovies.Areas.WebSeriesArea.Data.ViewModels
{
    public class NewWebSeriesDropDownVM
    {
        public NewWebSeriesDropDownVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
