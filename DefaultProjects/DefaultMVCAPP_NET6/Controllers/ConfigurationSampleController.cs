using DefaultMVCAPP_NET6.Models;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMVCAPP_NET6.Controllers
{
    public class ConfigurationSampleController : Controller
    {
        private IConfiguration _configuration; //IConfiguration ist das Sammelbecken aller eingelesenen Konfigurationen aus verschienden Quellen (Provider werden hier eingesetzt) 

        public ConfigurationSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ContentResult DisplayEnvironmentVariables() //In Razor Pages wäre diese Methode die OnGet
        {
            string str = string.Empty;

            foreach(KeyValuePair<string, string> pair in _configuration.AsEnumerable())
            {
                str = str + $"{pair.Key}  =  {pair.Value} + \n";
            }

            return Content(str);
            
        }

        public ContentResult DisplayAllProviders()
        {
            IConfigurationRoot configurationRoot = (IConfigurationRoot)_configuration;

            string str = "";
            foreach (var provider in configurationRoot.Providers.ToList())
            {
                str += provider.ToString() + "\n";
            }

            return Content(str);
        }

        public string ShowConfigurationExplizitSample()
        {
            var myKeyValue = _configuration["MyKey"];
            var title = _configuration["Position:Title"];
            var name = _configuration["Position:Name"];
            var defaultLogLevel = _configuration["Logging:LogLevel:Default"];

            
            return  $"MyKey value: {myKeyValue} \n" +
                           $"Title: {title} \n" +
                           $"Name: {name} \n" +
                           $"Default Log Level: {defaultLogLevel}";
        }


        public ContentResult ConfigurationOptionPattern()
        {
            PositionOptions positionOptions = new();

            _configuration.GetSection(PositionOptions.Position)
                         .Bind(positionOptions);

            return Content($"Title: {positionOptions.TiTle} \n" +
                           $"Name: {positionOptions.Name}");
        }
    }
}
