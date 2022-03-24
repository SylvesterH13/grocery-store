using GroceryStore.Api.Model.Domain;

namespace GroceryStore.Api.Repositories
{
    /// <summary>
    /// Repository to perform CRUD operations related to products.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Lists products optionally by the available filters.
        /// </summary>
        Task<IEnumerable<Product>> ListAsync(string? name = null, string? description = null, ProductCategory? category = null, int? rating = null,
            double? price = null, OrderType? orderType = null, ProductOrderProperty? orderProperty = null);
    }
}
