using System;
using CodeBase.Core.MVVM.ViewModel;
using CodeBase.Core.MVVM.WindowFsm;
using CodeBase.Sample.Presentation.Views;
using UnityEngine;

namespace CodeBase.Sample.Presentation.ViewModels
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