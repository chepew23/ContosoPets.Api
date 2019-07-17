using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoPets.Api.Data;
using ContosoPets.Api.Models;

namespace ContosoPets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ContosoPetsContext _context;

        public ProductsController(ContosoPetsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll() =>
            _context.Products.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(long Id)
        {
            var product = await this._context.Products.FindAsync(Id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            this._context.Add(product);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            this._context.Entry(product).State = EntityState.Modified;
            await this._context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var product = await this._context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            this._context.Products.Remove(product);
            await this._context.SaveChangesAsync();

            return NoContent();
        }
    }
}