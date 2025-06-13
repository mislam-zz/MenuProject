using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Data.Dtos;
using SampleProject.Data.Model;
using SampleProject.Service;

namespace SampleProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] List<OrderItems> orderItems)
        {
            var total = default(decimal); ;
            if (orderItems == null || !orderItems.Any())
            {
                return NotFound("Not found");
            }
            if (orderItems != null)
            {
                total = menuService.Calculate(orderItems);
            }
            return Ok(total);
        }
    }
}