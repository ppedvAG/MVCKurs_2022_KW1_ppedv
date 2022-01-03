using DefaultMVCAPP_NET6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DefaultMVCAPP_NET6.Controllers
{
    //IOptionsSnapshot -> ermöglicht das automatische wiedereinlesen, wenn Konfiguration-Datei im laufenden WebAPPStatus modifiziert wurde. 
    public class ConfigurationSample2Controller : Controller
    {
        private readonly PositionOptions _options;
        private readonly ArrayExample _array;
        private readonly GameSettings _settings;



        public ConfigurationSample2Controller(IOptionsSnapshot<PositionOptions> options, IOptionsSnapshot<ArrayExample> array, IOptionsSnapshot<GameSettings> gameSettings)
        {
            _options = options.Value;
            _array = array.Value; //kommen die Werte hier an. 
            _settings = gameSettings.Value;
        }

        public ContentResult Index()
        {
            return Content($"Title: {_options.TiTle} \n" +
                          $"Name: {_options.Name}");
        }


        public ContentResult Lab()
        {

            return Content($"{_settings.Title} {_settings.SubTitle} {_settings.Updates[0]}");
        }
    }
}
