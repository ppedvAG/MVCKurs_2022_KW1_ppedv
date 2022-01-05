using System.Globalization;

namespace MovieStoreSample.Models
{
    public class CultureSwitcherModel
    {
        public CultureInfo CurrentUICulture { get; set; } = default!;

        public List<CultureInfo> SupportedCultures { get; set; } = default!;
    }
}
