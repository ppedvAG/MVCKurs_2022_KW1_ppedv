namespace DefaultMVCAPP_NET6.Models
{
    public class GameSettings
    {
        public string Title { get; set; } = string.Empty;

        public string SubTitle { get; set; } = string.Empty;

        public string[] Updates { get; set; } = default!;
    }
}
