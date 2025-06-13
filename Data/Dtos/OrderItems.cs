namespace SampleProject.Data.Dtos
{
    public class OrderItems
    {
        public int MenuItemId { get; set; }
        public List<int> ModifierIds { get; set; } = new List<int>();
    }
}