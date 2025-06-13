using SampleProject.Data.Dtos;
using SampleProject.Data.Model;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleProject.Service
{
    public class MenuService : IMenuService
    {
        public MenuService()
        { }

        public async Task<decimal> Calculate(List<OrderItems> orderItems)
        {
            var total = 0m;

            foreach (var item in orderItems)
            {
                var menu = await GetMenuById(item.MenuItemId);
                if (menu == null)
                {
                    continue; // Skip if menu item not found
                }
                var basePrice = menu.BasePrice;
                var modifiersTotal = menu.Modifiers
                    .Where(modifier => item.ModifierIds.Contains(modifier.Id))
                    .Sum(modifier => modifier.Price);

                total += basePrice + modifiersTotal;
            }

            return total;
        }

        public Task<List<Menu>> GetMenus()
        {
            // Logic to retrieve all menus
            var menus = JsonSerializer.Deserialize<List<Menu>>(
                new MemoryStream(Encoding.UTF8.GetBytes("[{\"id\":1,\"name\":\"Margherita Pizza\",\"basePrice\":8.99,\"modifiers\":[{\"id\":101,\"name\":\"Extra Cheese\",\"price\":1.5},{\"id\":102,\"name\":\"Gluten‑Free Crust\",\"price\":2}]},{\"id\":2,\"name\":\"Veggie Burger\",\"basePrice\":7.49,\"modifiers\":[{\"id\":201,\"name\":\"Avocado\",\"price\":1.25},{\"id\":202,\"name\":\"Sweet Potato Fries\",\"price\":2}]},{\"id\":3,\"name\":\"Caesar Salad\",\"basePrice\":6.99,\"modifiers\":[{\"id\":301,\"name\":\"Grilled Chicken\",\"price\":2.5},{\"id\":302,\"name\":\"Bacon Bits\",\"price\":1}]}]")),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } }
            );

            return menus != null && menus.Count > 0 ? Task.FromResult(menus) : Task.FromResult(new List<Menu>());
        }

        private async Task<Menu?> GetMenuById(int menuId)
        {
            var menus = await GetMenus();
            var menu = menus.FirstOrDefault(m => m.Id == menuId);
            return menu;
        }
    }
}