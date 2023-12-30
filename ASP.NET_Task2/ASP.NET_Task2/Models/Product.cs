namespace ASP.NET_Task2.Models
{
    public class Product
    {
        public static int StaticId { get; set; } = 1;
        public int Id { get; set; } = StaticId++;
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public double Price { get; set; }
        public string? ImageUrl { get; set; } 
    }
}
