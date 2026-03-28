using AzureAppServiceAPI.Core.Interface;
using AzureAppServiceAPI.Data.Enteties;
using AzureAppServiceAPI.Data.Interfaces;

namespace AzureAppServiceAPI.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<Product>> GetAllProducts() => await _productRepo.GetAllProducts();
        public async Task<Product?> GetProductById(int id) => await _productRepo.GetProductById(id);
        public async Task AddProduct(Product product) => await _productRepo.AddProduct(product);
        public async Task UpdateProduct(Product product) => await _productRepo.UpdateProduct(product);
        public async Task DeleteProduct(int id) => await _productRepo.DeleteProduct(id);
    }
}
