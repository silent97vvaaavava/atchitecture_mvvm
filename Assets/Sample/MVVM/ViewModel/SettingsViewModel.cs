using System;
using Core.MVVM.ViewModel;
using Core.MVVM.Windows;
using Sample.MVVM.View;

namespace Sample.MVVM.ViewModel
{
    public class SettingsViewModel : AbstractViewModel
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
            _windowFsm.CloseWindow(Window);
        }
    }
}   