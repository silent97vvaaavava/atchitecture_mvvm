using System;
using Core.MVVM.ViewModel;
using Core.MVVM.Windows;
using Sample.Presentation.Models;
using Sample.Presentation.Views;

namespace Sample.Presentation.ViewModels
{
    public class CurtainViewModel : AbstractViewModel
    {
        private readonly CurtainModel _model;
        
        protected override Type Window => typeof(CurtainView);

        public CurtainViewModel(IWindowFsm windowFsm) : base(windowFsm)
        {
        }

        public override void InvokeOpen()
        {
        }

        public override void InvokeClose()
        {
        }
    }
}