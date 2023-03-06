using IPA;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using Radio.Configuration;
using Radio.Installers;

using IPALogger = IPA.Logging.Logger;
using Conf = IPA.Config.Config;
using Radio.Managers;

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
                Container.BindInterfacesAndSelfTo<SetupManager>().AsSingle();
            });

            zenjector.Install<MenuInstaller>(Location.Menu);
        }
    }
}
