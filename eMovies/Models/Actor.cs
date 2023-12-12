using System.ComponentModel.DataAnnotations;

namespace eMovies.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Display(Name ="Profile Picture")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        // Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
