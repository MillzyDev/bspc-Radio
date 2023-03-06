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
            _stationDictionary.Add("Default", GetDefaultStations());
            _stationDictionary = DictionaryUtils.Merge(_stationDictionary, GetUserStations());
        }

        public Station[] GetDefaultStations()
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

            return stations.ToArray();
        }

        public Dictionary<string, Station[]> GetUserStations()
        {
            string[] files = Directory.GetFiles(UserStationDir, "*.json");

            /* -- EXAMPLE USER STATION LIST --
             * {
             *  "name": "Cool Stations",
             *  "stations": {
             *      "TruckersFM": "url goes here",
             *   }
             * }
             */

            Dictionary<string, Station[]> userStations = new Dictionary<string, Station[]>();

            foreach (var file in files)
            {
                JObject parsed = JObject.Parse(File.ReadAllText(file));

                List<Station> stations = new List<Station>();

                string listName = parsed["name"].ToString();
                JObject stationList = (JObject)parsed["stations"];

                foreach (var pair in stationList)
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

                userStations.Add(listName, stations.ToArray());
            }

            return userStations;
        }
    }
}
