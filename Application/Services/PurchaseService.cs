using Application.DTOs;
using Application.DTOs.Validations;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var validate = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação.", validate);

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;
            return ResultService.OK<PurchaseDTO>(purchaseDTO);

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                return ResultService.Fail("Compra não encontrada");

            await _purchaseRepository.DeleteAsync(purchase);
            return ResultService.OK($"Compra do id:{id} foi deletada.");
        }

        public async Task<ResultService<ICollection<PurchaseDTO>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetPurchasesAsync();
            return ResultService.OK<ICollection<PurchaseDTO>>(_mapper.Map<ICollection<PurchaseDTO>>(purchases));
        }

        public async Task<ResultService<PurchaseDTO>> GetByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada");

            return ResultService.OK(_mapper.Map<PurchaseDTO>(purchase));
        }

        public async Task<ResultService> UpdateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos", validation);

            var purchase = await _purchaseRepository.GetByIdAsync(purchaseDTO.Id);
            if (purchase == null)
                return ResultService.Fail("Compra não encontrado");

            purchase = _mapper.Map<PurchaseDTO, Purchase>(purchaseDTO, purchase);
            await _purchaseRepository.EditAsync(purchase);
            return ResultService.OK("Compra editado");
        }
    }
}
