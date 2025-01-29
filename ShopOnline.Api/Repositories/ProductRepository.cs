using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            
        }
        public Task<IEnumerable<ProductCategory>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
