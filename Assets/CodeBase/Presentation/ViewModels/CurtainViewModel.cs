using System;
using CodeBase.Presentation.Models;
using CodeBase.Presentation.Views;

namespace CodeBase.Presentation.ViewModels
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