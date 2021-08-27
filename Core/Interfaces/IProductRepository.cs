using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();

        Task<ProductBrand> GetProductBrandsByIdAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<ProductType> GetProductTypesByIdAsync(int id);
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}