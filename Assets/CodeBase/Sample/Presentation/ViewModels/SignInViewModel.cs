using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Sample.Presentation.Views;

namespace Sample.Presentation.ViewModels
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