using System;
using CodeBase.Core.MVVM.ViewModel;
using CodeBase.Core.MVVM.WindowFsm;
using CodeBase.Sample.Presentation.Models;
using CodeBase.Sample.Presentation.Views;

namespace CodeBase.Sample.Presentation.ViewModels
{
    public class CurtainViewModel : BaseViewModel
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