using System;
using CodeBase.Presentation.Models;
using CodeBase.Presentation.Views;
using UnityEngine;

namespace CodeBase.Presentation.ViewModels
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