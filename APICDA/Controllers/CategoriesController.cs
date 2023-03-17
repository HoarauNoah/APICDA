using APICDA.Data;
using APICDA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICDA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ShopDbContext dbContext;

        public CategoriesController(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await dbContext.Categories.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCategory([FromRoute] Guid id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound(id);
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(ExposedCategory exposedCategory)
        {
            var category = new Category()
            {
                Name = exposedCategory.Name,
                Id = Guid.NewGuid()
            };
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> UpdateCategory([FromRoute] Guid id, ExposedCategory exposedCategory)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                category.Name = exposedCategory.Name;

                await dbContext.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                dbContext.Remove(category);
                await dbContext.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound();
        }
    }
}
