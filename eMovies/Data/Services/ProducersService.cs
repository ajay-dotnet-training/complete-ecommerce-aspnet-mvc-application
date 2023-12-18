using eMovies.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eMovies.Data.Services
{
    public class ProducersService : IProducersService
    {
        private readonly ApplicationDbContext _context;

        public ProducersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.Id == Id);
            _context.Producers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var result = await _context.Producers.ToListAsync();
            return result;
        }

        public async Task<Producer> GetByIdAsync(int Id)
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.Id == Id);
            return result;
        }

        public async Task<Producer> UpdateAsync(int Id, Producer producer)
        {
            _context.Update(producer);
            await _context.SaveChangesAsync();
            return producer;
        }
    }
}
