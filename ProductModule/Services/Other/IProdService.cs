using ProductClient.DTO;
using System.Text.Json.Nodes;

namespace ProductModule.Services.Other
{
    public interface IProdService
    {
        ProductDTO GetProduct(string productId);

        List<ProductDTO> SearchProducts(JsonObject searchParams);

        ProductDTO CreateProduct(ProductDTO productDTO);

        ProductDTO UpdateProduct(ProductDTO productDTO);

        void DeleteProduct(string productId);
    }
}
