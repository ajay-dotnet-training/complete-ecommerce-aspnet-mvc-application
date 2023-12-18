using eMovies.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Areas.WebSeriesArea.Data.ViewModels
{
    public class WebSeriesVM
    {
        public int Id { get; set; }

        [Display(Name = "WebSeries name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "WebSeries description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "WebSeries in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "WebSeries poster URL")]
        [Required(ErrorMessage = "WebSeries poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "WebSeries start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "WebSeries end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "WebSeries category is required")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "WebSeries actor(s) is required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "WebSeries cinema is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "WebSeries producer is required")]
        public int ProducerId { get; set; }
    }
}
