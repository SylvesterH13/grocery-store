using GroceryStore.Api.Extensions;
using GroceryStore.Api.Model.Domain;
using Newtonsoft.Json;

namespace GroceryStore.Api.Repositories
{
    /// <summary>
    /// An implementation of <see cref="IProductRepository"/> that uses a JSON file of products as a source of data.
    /// </summary>
    public class ProductJsonRepository : IProductRepository
    {
        private const string DATA_FILE_PATH = @"Data\Product\products.json";
        private readonly string _dataFileFullPath;

        public ProductJsonRepository()
        {
            _dataFileFullPath = Path.Combine(Environment.CurrentDirectory, DATA_FILE_PATH);
        }

        public async Task<IEnumerable<Product>> ListAsync(string? name = null, string? description = null, ProductCategory? category = null,
            int? rating = null, double? price = null, OrderType? orderType = null, ProductOrderProperty? orderProperty = null)
        {
            using var streamReader = new StreamReader(_dataFileFullPath);
            var data = await streamReader.ReadToEndAsync();

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(data);

            products = products
                .Where(p => string.IsNullOrWhiteSpace(name)        || p.Name.ContainsNormalized(name))
                .Where(p => string.IsNullOrWhiteSpace(description) || p.Description.ContainsNormalized(description))
                .Where(p => category is null || p.Category == category)
                .Where(p => rating is null || p.Rating == rating)
                .Where(p => price is null || p.Price == price);

            if (orderProperty != null)
            {
                return Order(products, orderType ?? OrderType.Asc, orderProperty.Value);
            }

            return products;
        }

        private IEnumerable<Product> Order(IEnumerable<Product> products, OrderType orderType, ProductOrderProperty productOrderProperty)
        {
            switch (orderType)
            {
                case OrderType.Asc:
                    switch (productOrderProperty)
                    {
                        case ProductOrderProperty.Name:
                            return products.OrderBy(p => p.Name);

                        case ProductOrderProperty.Description:
                            return products.OrderBy(p => p.Description);

                        case ProductOrderProperty.Category:
                            return products.OrderBy(p => p.Category);

                        case ProductOrderProperty.Rating:
                            return products.OrderBy(p => p.Rating);

                        case ProductOrderProperty.Price:
                            return products.OrderBy(p => p.Price);

                        default: throw new ArgumentOutOfRangeException(nameof(productOrderProperty));
                    }

                case OrderType.Desc:
                    switch (productOrderProperty)
                    {
                        case ProductOrderProperty.Name:
                            return products.OrderByDescending(p => p.Name);

                        case ProductOrderProperty.Description:
                            return products.OrderByDescending(p => p.Description);

                        case ProductOrderProperty.Category:
                            return products.OrderByDescending(p => p.Category);

                        case ProductOrderProperty.Rating:
                            return products.OrderByDescending(p => p.Rating);

                        case ProductOrderProperty.Price:
                            return products.OrderByDescending(p => p.Price);

                        default: throw new ArgumentOutOfRangeException(nameof(productOrderProperty));
                    }

                default: throw new ArgumentOutOfRangeException(nameof(orderType));
            }
        }
    }
}
