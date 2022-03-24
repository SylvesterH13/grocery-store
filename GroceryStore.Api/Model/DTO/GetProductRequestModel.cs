using GroceryStore.Api.Model.Domain;
using Newtonsoft.Json;

namespace GroceryStore.Api.Model.DTO
{
    public class GetProductRequestModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProductCategory? Category { get; set; }
        public int? Rating { get; set; }
        public double? Price { get; set; }

        [JsonProperty("orderBy")]
        public ProductOrderProperty? OrderProperty { get; set; }

        public OrderType? OrderType { get; set; }
    }
}
