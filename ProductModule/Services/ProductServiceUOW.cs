using AutoMapper;
using ProductClient.DTO;
using ProductModule.EntityProcessor;
using ProductModule.Models;
using System.Text.Json.Nodes;

namespace ProductModule.Services
{
    public class ProductServiceUOW : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductServiceUOW(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductDTO createProduct(ProductDTO productDTO)
        {
            Console.WriteLine("Saving Product using ProductService-UOW"); 
            Product product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Add(product);
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
            Product product = _unitOfWork.Products.GetById(productId);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public List<ProductDTO> searchProducts(JsonObject searchParams)
        {
            throw new NotImplementedException();
        }

        public ProductDTO updateProduct(ProductDTO productDTO)
        {
            Console.WriteLine("Updating Product using ProductService-UOW");
            //Product existingProduct = _unitOfWork.Products.GetById(productDTO.ProductId);
            Product product = _mapper.Map<Product>(productDTO);
            _unitOfWork.Products.Update(product);
            new ProductEntityProcessor(_unitOfWork).processEntity(product);
            _unitOfWork.Complete();
            productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
    }
}
