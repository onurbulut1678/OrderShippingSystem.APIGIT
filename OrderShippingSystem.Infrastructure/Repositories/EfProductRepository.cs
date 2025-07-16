﻿using OrderShippingSystem.Application.Interfaces;
using OrderShippingSystem.Domain.Entities;
using OrderShippingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderShippingSystem.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly OrderShippingDbContext _context;

        public EfProductRepository(OrderShippingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
//repostryler böyle olucaktı ama hata aldım
//using Microsoft.EntityFrameworkCore;
//using OrderShippingSystem.Domain.Entities;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace OrderShippingSystem.Infrastructure.Repositories
//{
//  public class EfProductRepository : IProductRepository
// {
//    private readonly OrderShippingDbContext _context;

//  public EfProductRepository(OrderShippingDbContext context)
//{
//  _context = context;
//}

//public async Task<List<Product>> GetAllAsync()
//{
//  return await _context.Products.ToListAsync();
//}

//public async Task<Product?> GetByIdAsync(int id)
//{
//  return await _context.Products.FindAsync(id);
//}

//        public async Task AddAsync(Product product)
//      {
//        await _context.Products.AddAsync(product);
//      await _context.SaveChangesAsync();
//}

//  public async Task UpdateAsync(Product product)
//{
//  _context.Products.Update(product);
//await _context.SaveChangesAsync();
//}

//public async Task DeleteAsync(Product product)
//{
//  _context.Products.Remove(product);
//  await _context.SaveChangesAsync();
//}
//}
//}
//
//repostryler böyle olucaktı ama hata aldım