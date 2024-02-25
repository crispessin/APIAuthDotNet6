using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetByIdAsync(int id);
        Task<ICollection<Purchase>> GetPurchasesAsync();
        Task<Purchase> CreateAsync(Purchase purchase);
        Task EditAsync(Purchase purchase);
        Task DeleteAsync(Purchase purchase);
    }
}
