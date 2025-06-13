using SampleProject.Data.Dtos;
using SampleProject.Data.Model;

namespace SampleProject.Service
{
    public interface IMenuService
    {
        decimal CalculateInternal(List<OrderItems> menus);

        List<Menu> GetMenus();
    }
}