using Radio.FlowCoordinators;
using Radio.Managers;
using System;
using Zenject;

namespace Radio.Installers
{
    public class RUIInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MenuButtonManager>().AsSingle();

            Container.Bind<RadioSettingsFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}
