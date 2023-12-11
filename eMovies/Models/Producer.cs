using System.ComponentModel.DataAnnotations;

namespace eMovies.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        // Relationships
        public List<Movie> Movies { get; set; }
    }
}
