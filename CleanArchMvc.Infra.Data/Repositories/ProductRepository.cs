﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int? id)
        {
            //return await _context.Products.FindAsync(id);
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _context.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        //public async Task<Product> GetProductCategory(int? id)
        //{
        //    //eager loading
        //    return await _context.Products.Include(c => c.Category)
        //        .SingleOrDefaultAsync(p => p.Id == id);
        //}

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Remove(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
