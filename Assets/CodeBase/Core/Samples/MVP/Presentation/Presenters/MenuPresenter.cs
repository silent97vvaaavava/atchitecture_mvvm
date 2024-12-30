using System;
using Core.Infrastructure.WindowsFsm;
using Core.MVP.Presenters;
using Core.Samples.MVP.Presentation.Views;
using Core.Samples.Shared.Windows;

namespace Core.Samples.MVP.Presentation.Presenters
{
    public class MenuPresenter : IPresenter
    {
        private readonly MenuView _view;
        private readonly IWindowFsm _windowFsm;
        private readonly Type _window = typeof(Menu);

        public MenuPresenter(
            MenuView view,
            IWindowFsm windowFsm)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _windowFsm = windowFsm ?? throw new ArgumentNullException(nameof(windowFsm));
        }

        public void Enable()
        {
            _windowFsm.Opened += OnHandleOpenWindow;
            _windowFsm.Closed += OnHandleCloseWindow;
            
            _view.SettingsButton.onClick.AddListener(OnOpenSettings);
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
            
            _view.SettingsButton.onClick.RemoveListener(OnOpenSettings);
        }

        private void OnOpenSettings()
        {
            _windowFsm.OpenWindow(typeof(Settings), true);
        }
        
        private void OnHandleOpenWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Show();
        }
        
        private void OnHandleCloseWindow(Type window)
        {
            if(_window != window || _view == null) return;
            
            _view.Hide();
        }
    }
}