﻿using Microsoft.EntityFrameworkCore;
using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderShippingSystem.Infrastructure.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OrderShippingDbContext _context;

        public EfGenericRepository(OrderShippingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
