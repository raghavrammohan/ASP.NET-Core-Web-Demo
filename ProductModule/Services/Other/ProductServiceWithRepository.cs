using AutoMapper;
using ProductClient.DTO;
using ProductModule.Models;
using ProductModule.Repository;
using System.Text.Json.Nodes;

namespace ProductModule.Services.Other
{
    public class ProductServiceWithRepository : IProdService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ApplicationDbContext _context;

        public ProductServiceWithRepository(IProductRepository productRepository, IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _context = context;
        }

        public ProductDTO CreateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            Console.WriteLine("Saving Products - ProductRepository");
            _productRepository.Add(product);
            _context.SaveChanges();
            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public void DeleteProduct(string productId)
        {
            Product product = new Product() { ProductId = productId };
            _productRepository.Remove(product);
            _context.SaveChanges();
        }

        public ProductDTO GetProduct(string productId)
        {
            Product product = _productRepository.GetById(productId).Result;
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public List<ProductDTO> SearchProducts(JsonObject searchParams)
        {
            var products = _productRepository.GetAll().Result;
            List<ProductDTO> result = new List<ProductDTO>();
            foreach (var prod in products)
            {
                result.Add(_mapper.Map<ProductDTO>(prod));
            }
            return result;
        }

        public ProductDTO UpdateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            Console.WriteLine("Updating Products - ProductRepository");
            _productRepository.Update(product, product.ProductId);
            _context.SaveChanges();
            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
    }
}
