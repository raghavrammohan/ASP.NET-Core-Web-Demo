using ProductClient.DTO;
using System.Text.Json.Nodes;

namespace ProductModule.Services;

public interface IProductService
{
    Task<ProductDTO> GetProduct(string productId);
    Task<List<ProductDTO>> SearchProducts(JsonObject searchParams);
    Task<ProductDTO> CreateProduct(ProductDTO productDTO);
    Task<ProductDTO> UpdateProduct(ProductDTO productDTO);
    Task DeleteProduct(string productId);
}
