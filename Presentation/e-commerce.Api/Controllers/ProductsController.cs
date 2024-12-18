using E_commerce_.netcore.Application.Features.Products.Commands.CreateProduct;
using E_commerce_.netcore.Application.Features.Products.Commands.DeleteProduct;
using E_commerce_.netcore.Application.Features.Products.Queries.GetAllProducts;
using E_commerce_.netcore.Application.Features.Products.Queries.GetProduct;
using E_commerce_.netcore.Application.Features.Products.Commands.UpdateProduct;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() 
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var request = new GetProductQueryRequest { Id = id };
           var response= await mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public  async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var request = new DeleteProductCommandRequest { Id = id };
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
