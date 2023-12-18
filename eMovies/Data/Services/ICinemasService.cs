using eMovies.Models;

namespace eMovies.Data.Services
{
    public interface ICinemasService 
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int Id);
        Task AddAsync(Cinema cinema);
        Task<Cinema> UpdateAsync(int Id, Cinema cinema);
        Task DeleteAsync(int Id);

    }
}
