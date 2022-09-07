using Common.PDFProcessing;
using Microsoft.AspNetCore.Mvc;
using ProductClient.DTO;
using ProductModule.Services;

namespace ProductModule.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IPDFProcessor _pdfProcessor;

    public ProductController(IEnumerable<IProductService> productServices, IPDFProcessor pdfProcessor)
    {
        //_productService = productServices.SingleOrDefault(s => s.GetType() == typeof(ProductServiceDbContext));
        _productService = productServices.SingleOrDefault(s => s.GetType() == typeof(ProductService));
        //_productService = productServices.SingleOrDefault(s => s.GetType() == typeof(ProductServiceUOW));
        _pdfProcessor = pdfProcessor;
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

    [HttpGet("processPDF")]
    public IActionResult ProcessPDF()
    {
        _pdfProcessor.processPDF();
        return Ok();
    }

    [HttpGet("generatePDF")]
    public IActionResult GeneratePDF()
    {
        _pdfProcessor.generatePDF();
        return Ok();
    }
}