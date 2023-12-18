using eMovies.Data.ViewModels;
using eMovies.Models;
using System.Linq.Expressions;

namespace eMovies.Data.Services
{
    public interface IMoviesService // : IEntityBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllAsync(params Expression<Func<Movie, object>>[] includeProperties);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
