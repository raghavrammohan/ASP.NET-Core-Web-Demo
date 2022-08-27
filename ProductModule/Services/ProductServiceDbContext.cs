using AutoMapper;
using ProductClient.DTO;
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
        Models.Product product = _context.Product.FirstOrDefault(p => p.ProductId == productId);
        ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    public ProductDTO createProduct(ProductDTO productDTO)
    {
        Models.Product product = _mapper.Map<Models.Product>(productDTO);
        Console.WriteLine("Saving ProductModule");
        _context.Product.Add(product);
        _context.SaveChanges();
        productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    ProductDTO IProductService.updateProduct(ProductDTO productDTO)
    {
        Models.Product product = _mapper.Map<Models.Product>(productDTO);
        Console.WriteLine("Updating ProductModule");
        _context.Product.Update(product);
        _context.SaveChanges();
        productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    void IProductService.deleteProduct(string productId)
    {
        Console.WriteLine("Deleting ProductModule with ProductModule Id :: " + productId);
        _context.Remove(productId);
        _context.SaveChanges();
    }

    List<ProductDTO> IProductService.searchProducts(JsonObject searchParams)
    {
        Console.WriteLine(searchParams);
        throw new NotImplementedException();
    }
}