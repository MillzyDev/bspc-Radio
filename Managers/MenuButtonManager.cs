using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using Radio.FlowCoordinators;
using System;
using Zenject;

namespace Radio.Managers
{
    public class MenuButtonManager : IInitializable, IDisposable
    {
        [Inject]
        private MainFlowCoordinator _mainFlowCoordinator;
        [Inject]
        private RadioSettingsFlowCoordinator _radioSettingsFlowCoordinator;

        private readonly MenuButton _menuButton;

        MenuButtonManager() 
        {
            _menuButton = new MenuButton(nameof(Radio), ShowFlowCoordinator);
        }

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(_menuButton);
        }

        private void ShowFlowCoordinator()
        {
            _mainFlowCoordinator.PresentFlowCoordinator(_radioSettingsFlowCoordinator, animationDirection: HMUI.ViewController.AnimationDirection.Vertical);
        }

        public void Dispose()
        {
            if (BSMLParser.IsSingletonAvailable && MenuButtons.IsSingletonAvailable)
                MenuButtons.instance.UnregisterButton(_menuButton);
        }
    }
}
