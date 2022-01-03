namespace DefaultMVCAPP_NET6.Models
{
    public class PositionOptions
    {
        public const string Position = "Position";

        public string TiTle { get; set; } = string.Empty;
        public string Name { get; set; } = default!; //Ist Neu in .NET 6


    }
}
