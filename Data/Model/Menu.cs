namespace SampleProject.Data.Model
{
    public class Menu
    {
        public int Id { get; set; } // Unique identifier for the menu item
        public string? Name { get; set; }
        public decimal BasePrice { get; set; } // Price of the menu item
        public ICollection<Modifier> Modifiers { get; set; } = default!; // Collection of modifiers for the menu item

        // Constructor to initialize the menu item
    }
}