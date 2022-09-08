using AutoMapper;
using ProductClient.DTO;
using ProductModule.Models;
using System.Text.Json.Nodes;

namespace ProductModule.Services.Other;

public class ProductServiceDbContext : IProdService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public ProductServiceDbContext(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public ProductDTO GetProduct(string productId)
    {
        Product product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
        ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    public ProductDTO CreateProduct(ProductDTO productDTO)
    {
        Product product = _mapper.Map<Product>(productDTO);
        Console.WriteLine("Saving Products - DbContext");
        _context.Products.Add(product);
        _context.SaveChanges();
        productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    public ProductDTO UpdateProduct(ProductDTO productDTO)
    {
        Product product = _mapper.Map<Product>(productDTO);
        Console.WriteLine("Updating Products - DbContext");
        _context.Products.Update(product);
        _context.SaveChanges();
        productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }

    public void DeleteProduct(string productId)
    {
        Console.WriteLine("Deleting Products (DbContext) with Products Id :: " + productId);
        _context.Remove(productId);
        _context.SaveChanges();
    }

    public List<ProductDTO> SearchProducts(JsonObject searchParams)
    {
        Console.WriteLine(searchParams);
        throw new NotImplementedException();
    }

}