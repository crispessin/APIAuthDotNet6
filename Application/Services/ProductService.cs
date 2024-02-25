using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("Objeto deve ser informado!");

            var result = new ProductDTOValidator().Validate(productDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Probelmas na validação", result);

            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.CreateAsync(product);
            return ResultService.OK(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado");

            await _productRepository.DeleteAsync(product);
            return ResultService.OK($"Produto do id:{id} foi deletado.");
        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return ResultService.OK<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail<ProductDTO>("Produto não encontrado");

            return ResultService.OK(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new ProductDTOValidator().Validate(productDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos", validation);

            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado");

            product = _mapper.Map<ProductDTO, Product>(productDTO, product);
            await _productRepository.EditAsync(product);
            return ResultService.OK("Produto editado");
        }
    }
}
