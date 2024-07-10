using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.MVVM.View;
using UnityEngine;

namespace Training.MVVM.ViewModel
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
            //_windowFsm.CloseCurrentWindow();
            _windowFsm.CloseWindow(Window);
        }
    }
}   