using eMovies.Models;

namespace eMovies.Data.Services
{
    public interface IProducersService //: IEntityBaseRepository<Producer>
    {
        Task<IEnumerable<Producer>> GetAllAsync();
        Task<Producer> GetByIdAsync(int Id);
        Task AddAsync(Producer producer);
        Task<Producer>UpdateAsync(int Id, Producer producer);
        Task DeleteAsync(int Id);
    }
}
