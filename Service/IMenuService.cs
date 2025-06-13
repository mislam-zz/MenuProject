using SampleProject.Data.Dtos;
using SampleProject.Data.Model;

namespace SampleProject.Service
{
    public interface IMenuService
    {
        Task<decimal> Calculate(List<OrderItems> menus);
    }
}