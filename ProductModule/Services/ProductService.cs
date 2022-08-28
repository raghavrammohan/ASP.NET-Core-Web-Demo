using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductClient.DTO;
using ProductModule.Models;
using ProductModule.Repository;
using System.Text.Json.Nodes;

namespace ProductModule.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public ProductDTO createProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            Console.WriteLine("Saving ProductModule");
            _productRepository.Add(product);
            _productRepository.Save();
            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public void deleteProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public ProductDTO getProduct(string productId)
        {
            Product product = _productRepository.GetById(productId);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public List<ProductDTO> searchProducts(JsonObject searchParams)
        {
            throw new NotImplementedException();
        }

        public ProductDTO updateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            Console.WriteLine("Updating ProductModule");
            _productRepository.Add(product);
            _productRepository.Save();
            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
    }
}
