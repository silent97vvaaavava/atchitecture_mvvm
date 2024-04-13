using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Sample.Presentation.Views;
using UnityEngine;

namespace Sample.Presentation.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        protected override Type Window => typeof(SettingsView);

        public SettingsViewModel(IWindowFsm windowFsm) : base(windowFsm)
        {
            
        }

        public override void InvokeOpen()
        {
            
        }

        public override void InvokeClose()
        {
            Debug.Log("Close");
            _windowFsm.CloseCurrentWindow();
        }
    }
}