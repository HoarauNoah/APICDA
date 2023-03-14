using APICDA.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetCategories()
        {
            return Ok(dbContext.Categories.ToList());
        }
    }
}
