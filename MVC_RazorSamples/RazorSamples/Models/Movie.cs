namespace RazorSamples.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
