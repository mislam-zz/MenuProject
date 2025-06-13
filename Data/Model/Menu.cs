namespace SampleProject.Data.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal BasePrice { get; set; } 
        public ICollection<Modifier> Modifiers { get; set; } = default!; 
    }
}