using DefaultMVCAPP_NET6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DefaultMVCAPP_NET6.Controllers
{
    //IOptionsSnapshot -> ermöglicht das automatische wiedereinlesen, wenn Konfiguration-Datei im laufenden WebAPPStatus modifiziert wurde. 
    public class ConfigurationSample2Controller : Controller
    {
        private readonly PositionOptions _options;
        public readonly ArrayExample _array;


        public ConfigurationSample2Controller(IOptionsSnapshot<PositionOptions> options, IOptionsSnapshot<ArrayExample> array)
        {
            _options = options.Value;
            _array = array.Value; //kommen die Werte hier an. 
        }

        public ContentResult Index()
        {
            return Content($"Title: {_options.TiTle} \n" +
                          $"Name: {_options.Name}");
        }
    }
}
