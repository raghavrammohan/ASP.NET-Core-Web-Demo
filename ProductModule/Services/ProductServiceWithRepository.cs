using AutoMapper;
using Common.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductClient.DTO;
using ProductModule.Models;
using ProductModule.Repository;
using System.Text.Json.Nodes;

namespace ProductModule.Services
{
    public class ProductServiceWithRepository : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithRepository(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public ProductDTO createProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            Console.WriteLine("Saving Products - ProductRepository");
            _productRepository.Add(product);
            _unitOfWork.Complete();
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
            Console.WriteLine("Updating Products - ProductRepository");
            _productRepository.Update(product);
            _unitOfWork.Complete();
            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
    }
}
