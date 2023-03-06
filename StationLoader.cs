using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Zenject;
using IPALogger = IPA.Logging.Logger;

namespace Radio
{
    public class StationLoader // StationLoader? But I hardly know 'er!
    {
        [Inject]
        private IPALogger logger;

        private static string UserStationDir
        {
            get
            {
                return Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "UserData",
                    "Radio"
                    );
            }
        }

        private Dictionary<string, Station[]> _stationDictionary;

        private StationLoader() 
        {
            AbleToLoad = true;
            Errors = new List<string>();
            _stationDictionary = new Dictionary<string, Station[]>();
        }

        public bool AbleToLoad { get; set; }

        public List<string> Errors { get; set; }

        public void LoadAllStations()
        {
            _stationDictionary.Add("Default", LoadDefaultStations());
            _stationDictionary = DictionaryUtils.Merge(_stationDictionary, LoadUserStations());
        }

        public Station[] LoadDefaultStations()
        {
            string file = AssemblyUtils.ReadResourceAsString("Radio.Resources.stations.json");
            JObject parsed = JObject.Parse(file);

            List<Station> stations = new List<Station>();
            
            foreach (var pair in parsed)
            {
                string name = pair.Key;
                string url = pair.Value.ToString();

                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    logger.Error($"Unable to load station {name} - Value is not a valid URL");
                    continue;
                }


                stations.Add(new Station(name, url));
            }
        }

        public Dictionary<string, Station[]> LoadUserStations()
        {

        }
    }
}
