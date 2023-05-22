using Bra.ProductApi.Model.Dto;

namespace Bra.ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int ProductId);
        Task<ProductDto> CreateUpdateProduct (ProductDto productDto);
        Task<bool> DeleteProduct (int ProductId);
    }
}
