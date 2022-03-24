namespace GroceryStore.Api.Model.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
    }
}
