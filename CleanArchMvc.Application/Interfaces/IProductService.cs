using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task<ProductDTO> GetProductCategory(int? id);

        Task add(ProductDTO productDTO);
        Task remove(int? id);
        Task update(ProductDTO productDTO);
    }
}
