using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db?.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> GetProductAsync()
        {
            return await _db.Product.ToListAsync();
        }
    }
}
