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

        public decimal CalculateInternal(List<OrderItems> menus)
        {
            var total = menus.Sum(item =>
            {
                // Assuming we have a method to get the menu by ID and its modifiers
                var menu = GetMenuById(item.MenuItemId);
                if (menu == null) return 0;
                var basePrice = menu.BasePrice;
                var modifierPrice = item.ModifierIds.Sum(modifierId =>
                    menu.Modifiers.FirstOrDefault(m => m.Id == modifierId)?.Price ?? 0);
                return basePrice + modifierPrice;
            });

            return total;
        }

        private decimal Calculate(List<OrderItems> menus)
        {
            return Calculate(menus);
        }

        public List<Menu> GetMenus()
        {
            // Logic to retrieve all menus
            var menus = JsonSerializer.Deserialize<List<Menu>>(
                new MemoryStream(Encoding.UTF8.GetBytes("[{\"id\":1,\"name\":\"Margherita Pizza\",\"basePrice\":8.99,\"modifiers\":[{\"id\":101,\"name\":\"Extra Cheese\",\"price\":1.5},{\"id\":102,\"name\":\"Gluten‑Free Crust\",\"price\":2}]},{\"id\":2,\"name\":\"Veggie Burger\",\"basePrice\":7.49,\"modifiers\":[{\"id\":201,\"name\":\"Avocado\",\"price\":1.25},{\"id\":202,\"name\":\"Sweet Potato Fries\",\"price\":2}]},{\"id\":3,\"name\":\"Caesar Salad\",\"basePrice\":6.99,\"modifiers\":[{\"id\":301,\"name\":\"Grilled Chicken\",\"price\":2.5},{\"id\":302,\"name\":\"Bacon Bits\",\"price\":1}]}]")),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new JsonStringEnumConverter() } }
            );

            return menus != null && menus.Count > 0 ? menus : new List<Menu>(); // Return an empty list if deserialization fails
        }

        private Menu? GetMenuById(int menuId)
        {
            var menus = GetMenus();
            var menu = menus.FirstOrDefault(m => m.Id == menuId);
            return menu ?? null; // Return null if no menu found with the given ID
        }
    }
}