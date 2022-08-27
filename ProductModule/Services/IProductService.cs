using ProductClient.DTO;
using System.Text.Json.Nodes;

namespace ProductModule.Services;

public interface IProductService
{
    ProductDTO getProduct(string productId);

    List<ProductDTO> searchProducts(JsonObject searchParams);

    ProductDTO createProduct(ProductDTO productDTO);

    ProductDTO updateProduct(ProductDTO productDTO);

    void deleteProduct(string productId);
}