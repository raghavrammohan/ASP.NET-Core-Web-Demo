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

    public ProductController(IProductService productService, IPDFProcessor pdfProcessor /*, IEnumerable<IProdService> prodServices */)
    {
        //_productService = prodServices.SingleOrDefault(s => s.GetType() == typeof(ProductServiceDbContext));
        //_productService = prodServices.SingleOrDefault(s => s.GetType() == typeof(ProductServiceWithRepository));
        _productService = productService;
        _pdfProcessor = pdfProcessor;
    }

    [HttpGet("GetProduct/{productId}")]
    public async Task<IActionResult> GetProduct(string productId)
    {
        var response = await _productService.GetProduct(productId);
        return Ok(response);
    }

    [HttpPost("/CreateProduct")]
    public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
    {
        var response = await _productService.CreateProduct(productDTO);
        return Ok(response);
    }

    [HttpPut("/UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
    {
        var response = await _productService.UpdateProduct(productDTO);
        return Ok(response);
    }

    [HttpDelete("/DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(string productId)
    {
        await _productService.DeleteProduct(productId);
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