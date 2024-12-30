using System;
using Core.Infrastructure.WindowsFsm;
using Core.MVVM.ViewModel;
using Core.Samples.Shared.Windows;
using UnityEngine;

namespace Core.Samples.MVVM.Presentation.ViewModels
{
    public class SettingsViewModel : AbstractViewModel
    {
        public SettingsViewModel(IWindowFsm windowFsm) : base(windowFsm)
        {
        }

        protected override Type Window => typeof(Settings);

        public override void OnInvokeClose()
        {
            _windowFsm.CloseWindow();
        }

        protected override void HandleOpenedWindow(Type uiWindow)
        {
            Debug.Log($"HandleOpenedWindow: {uiWindow} -- {Window}");
            base.HandleOpenedWindow(uiWindow);
        }
    }
}