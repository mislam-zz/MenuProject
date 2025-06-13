namespace SampleProject.Data.Model
{
    public class Modifier
    {
        public int Id { get; set; } // Unique identifier for the modifier
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; } // Foreign key to the associated menu item
    }
}