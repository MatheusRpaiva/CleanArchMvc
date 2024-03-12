using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    internal interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int? id);

        Task<Product> GetProductCategory(int? id);

        Task<Product> Create(Product category);
        Task<Product> Update(Product category);
        Task<Product> Remove(Product category);
    }
}
