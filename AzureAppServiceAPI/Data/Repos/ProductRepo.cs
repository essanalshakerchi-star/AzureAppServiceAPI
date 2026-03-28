using AzureAppServiceAPI.Context;
using AzureAppServiceAPI.Data.Enteties;
using AzureAppServiceAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AzureAppServiceAPI.Data.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var befintligProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (befintligProduct != null)
            {
                befintligProduct.Name = product.Name;
                befintligProduct.Description = product.Description;
                befintligProduct.Price = product.Price;
                befintligProduct.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
