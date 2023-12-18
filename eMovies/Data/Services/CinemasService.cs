using eMovies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace eMovies.Data.Services
{
    public class CinemasService : ICinemasService
    {
        private readonly ApplicationDbContext _context;

        public CinemasService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var result = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == Id);
            _context.Cinemas.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var result = await _context.Cinemas.ToListAsync();
            return result;
        }

        public async Task<Cinema> GetByIdAsync(int Id)
        {
            var result = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == Id);
            return result;
        }

        public async Task<Cinema> UpdateAsync(int Id, Cinema cinema)
        {
            _context.Update(cinema);
            await _context.SaveChangesAsync();
            return cinema;
        }
    }
}
