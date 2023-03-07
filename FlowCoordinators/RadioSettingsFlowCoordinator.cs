using HMUI;
using Radio.Configuration;
using SiraUtil.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Radio.FlowCoordinators
{
    public class RadioSettingsFlowCoordinator : FlowCoordinator
    {
        [Inject]
        private PluginConfig _config;
        [Inject]
        private SiraLog _logger;
        [Inject]
        private MainFlowCoordinator _mainFlowCoordinator;

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle(nameof(Radio));
                showBackButton = true;

                //ProvideInitialViewControllers()
            }
        }
    }
}
