using Application.DTOs;

namespace Application.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
        Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync();
        Task<ResultService> UpdateAsync(PurchaseDTO purchaseDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
