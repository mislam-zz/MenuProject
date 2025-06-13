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
                return NotFound("Not found"); // Fixed the issue by replacing the incorrect usage of NotFoundResult with NotFound().
            }
            if (orderItems != null)
            {
                total = menuService.CalculateInternal(convertToMenuItem(convertToMenu(orderItems)));
            }
            return Ok(total);
        }

        private List<OrderItems> convertToMenuItem(List<Menu> menus)
        {
            return menus.Select(menu => new OrderItems
            {
                MenuItemId = menu.Id,
                ModifierIds = menu.Modifiers.Select(modifier => modifier.Id).ToList()
            }).ToList();
        }

        private List<Menu> convertToMenu(List<OrderItems> menus)
        {
            return menus.Select(item => new Menu
            {
                Id = item.MenuItemId,
                Modifiers = item.ModifierIds.Select(modifierId => new Modifier { Id = modifierId }).ToList()
            }).ToList();
        }
    }
}