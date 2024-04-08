using System;
using CodeBase.Core.MVVM.ViewModel;
using CodeBase.Core.MVVM.WindowFsm;
using CodeBase.Sample.Presentation.Views;

namespace CodeBase.Sample.Presentation.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;

        protected override Type Window => typeof(SignInView);

        public SignInViewModel(IWindowFsm windowFsm) : base(windowFsm)
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