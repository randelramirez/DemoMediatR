using System;
using System.Threading.Tasks;
using Application;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService service;
        private readonly IMediator mediator;

        public ProductsController(IProductsService service, IMediator mediator)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.mediator = mediator ?? throw  new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await  this.mediator.Send(new GetProductsQuery()));
        
        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var product = service.GetAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductModel model)
        {
            var response = await  this.mediator.Send(new CreateProductCommand(model));
            if (response.Success is not  true)
            {
                return BadRequest(response.ValidationErrors);
            }

            return Ok(response.Product);
            //return CreatedAtAction()
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]  UpdateProductModel model)
        {
            var response = await this.mediator.Send(new UpdateProductCommand(id, model));

            if (!response.Exists)
            {
                return NotFound();
            }

            if (!response.Success)
            {
                return BadRequest(new {Errors = response.ValidationErrors});
            }

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}