using Microsoft.AspNetCore.Mvc;
using ProductClient.DTO;
using ProductModule.Services;

namespace ProductModule.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IEnumerable<IProductService> productServices)
    {
        //_productService = productServices.SingleOrDefault(s => s.GetType() == typeof(ProductServiceDbContext));
        _productService = productServices.SingleOrDefault(s => s.GetType() == typeof(ProductService));
    }

    [HttpGet("getProduct/{productId}")]
    public IActionResult GetProduct(string productId)
    {
        var response = _productService.getProduct(productId);
        return Ok(response);
    }

    [HttpPost("/createProduct")]
    public IActionResult CreateProduct(ProductDTO productDTO)
    {
        var response = _productService.createProduct(productDTO);
        return Ok(response);
    }

    [HttpPut("/updateProduct")]
    public IActionResult UpdateProduct(ProductDTO productDTO)
    {
        var response = _productService.updateProduct(productDTO);
        return Ok(response);
    }

    [HttpDelete("/deleteProduct")]
    public IActionResult DeleteProduct(string productId)
    {
        _productService.deleteProduct(productId);
        return NoContent();
    }
}