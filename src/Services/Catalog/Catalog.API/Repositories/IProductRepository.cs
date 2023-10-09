using Catalog.API.Entities;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);

        Task<IEnumerable<Product>> GetProductbyName(string name);

        Task<IEnumerable<Product>> GetProductbyCategory(string category);

        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);

    }
}
