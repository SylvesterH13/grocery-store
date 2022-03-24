using GroceryStore.Api.Model.DTO;
using GroceryStore.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductRequestModel getProductRequestModel)
        {
            var products = await _productRepository.ListAsync(name: getProductRequestModel.Name,
                description: getProductRequestModel.Description,
                category: getProductRequestModel.Category,
                rating: getProductRequestModel.Rating,
                price: getProductRequestModel.Price,
                orderProperty: getProductRequestModel.OrderProperty,
                orderType: getProductRequestModel.OrderType
                );

            return Ok(products);
        }
    }
}
