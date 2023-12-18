using eMovies.Models;

namespace eMovies.Data.Services
{
    public interface IActorsService
    {
       Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int Id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int Id , Actor newActor);
        Task DeleteAsync(int Id);
    }
}
