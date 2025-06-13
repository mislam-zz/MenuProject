namespace SampleProject.Data.Dtos
{
    public class OrderItems
    {
        public int MenuItemId { get; set; } // Unique identifier for the menu item
        public List<int> ModifierIds { get; set; } = new List<int>(); // List of modifier IDs associated with the menu item
    }
}