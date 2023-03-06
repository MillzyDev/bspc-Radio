using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Radio.Managers
{
    public class SetupManager : IInitializable
    {
        [Inject]
        private StationLoader stationLoader;

        public void Initialize()
        {
            if (!NetUtils.InternetGetConnected())
            {
                stationLoader.AbleToLoad = false;
                stationLoader.Errors.Add("No internet connection");
            }
        }
    }
}
