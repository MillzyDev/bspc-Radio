using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using Conf = IPA.Config.Config;
using SiraUtil.Zenject;
using IPA.Loader;
using Radio.Configuration;
using Radio.Installers;

namespace Radio
{
    [Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        public void Init(Conf conf, IPALogger logger, Zenjector zenjector)
        {
            PluginConfig config = conf.Generated<PluginConfig>();
            zenjector.UseLogger(logger);
            zenjector.Install(Location.App, Container =>
            {
                Container.Bind<PluginConfig>().FromInstance(config).AsSingle();
                Container.Bind<Plugin>().FromInstance(this).AsSingle();
            });
            zenjector.Install<MenuInstaller>(Location.Menu);
        }
    }
}
