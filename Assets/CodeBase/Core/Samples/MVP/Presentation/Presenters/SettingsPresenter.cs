using System;
using Core.Infrastructure.WindowsFsm;
using Core.MVP.Presenters;
using Core.Samples.MVP.Presentation.Views;
using Core.Samples.Shared.Windows;

namespace Core.Samples.MVP.Presentation.Presenters
{
    public class SettingsPresenter : IPresenter
    {
        private readonly SettingsView _view;
        private readonly IWindowFsm _windowFsm;
        private readonly Type _window = typeof(Settings);
        
        
        public SettingsPresenter(
            SettingsView view,
            IWindowFsm windowFsm)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _windowFsm = windowFsm ?? throw new ArgumentNullException(nameof(windowFsm));
            
        }

        public void Enable()
        {
            _windowFsm.Opened += OnHandleOpenWindow;
            _windowFsm.Closed += OnHandleCloseWindow;
            
            _view.CloseButton.onClick.AddListener(OnClose);
        }

        public void Disable()
        {
            _windowFsm.Opened -= OnHandleOpenWindow;
            _windowFsm.Closed -= OnHandleCloseWindow;
            
            _view.CloseButton.onClick.RemoveListener(OnClose);
        }

        private void OnClose()
        {
            _windowFsm.CloseWindow();
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