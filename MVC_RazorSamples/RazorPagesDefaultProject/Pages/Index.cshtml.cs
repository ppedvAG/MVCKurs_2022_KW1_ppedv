using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDefaultProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

        }

        //Daten in Oberfläche mithilfe von Properties 

        public string Capital { get; set; } = default!;

        public void OnGet()
        {
            //Hier ist die letzte Chance die Daten zu manipulieren, bevor diese an die UI übergeben werden 

            Capital = "Brüssel";
        }
    }
}