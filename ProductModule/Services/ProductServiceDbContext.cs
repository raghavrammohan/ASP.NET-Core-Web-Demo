using AutoMapper;
using ProductClient.DTO;
using ProductModule.Models;
using System.Text.Json.Nodes;

namespace ProductModule.Services;

public class ProductServiceDbContext : IProductService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductServiceDbContext(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public ProductDTO getProduct(string productId)
    {
        Product product = _context.Product.FirstOrDefault(p => p.ProductId == productId);
        ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    public ProductDTO createProduct(ProductDTO productDTO)
    {
        Product product = _mapper.Map<Product>(productDTO);
        Console.WriteLine("Saving Product - DbContext");
        _context.Product.Add(product);
        _context.SaveChanges();
        productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    public ProductDTO updateProduct(ProductDTO productDTO)
    {
        Product product = _mapper.Map<Product>(productDTO);
        Console.WriteLine("Updating Product - DbContext");
        _context.Product.Update(product);
        _context.SaveChanges();
        productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    public void deleteProduct(string productId)
    {
        Console.WriteLine("Deleting Product (DbContext) with Product Id :: " + productId);
        _context.Remove(productId);
        _context.SaveChanges();
    }

    public List<ProductDTO> searchProducts(JsonObject searchParams)
    {
        Console.WriteLine(searchParams);
        throw new NotImplementedException();
    }

    ProductDTO IProductService.updateProduct(ProductDTO productDTO)
    {
        throw new NotImplementedException();
    }
}