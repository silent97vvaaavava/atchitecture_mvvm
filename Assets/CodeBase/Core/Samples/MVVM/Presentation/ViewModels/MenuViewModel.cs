using System;
using Core.Infrastructure.WindowsFsm;
using Core.MVVM.ViewModel;
using Core.Samples.Shared.Windows;
using UnityEngine;

namespace Core.Samples.MVVM.Presentation.ViewModels
{
    public class MenuViewModel : AbstractViewModel
    {
        public MenuViewModel(IWindowFsm windowFsm) : base(windowFsm)
        {
        }

        protected override Type Window => typeof(Menu);

        public void OnOpenSettings()
        {
            Debug.Log("Open Settings");
            _windowFsm.OpenWindow(typeof(Settings), true);
        }
    }
}