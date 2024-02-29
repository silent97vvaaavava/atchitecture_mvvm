using System;
using CodeBase.Presentation.Views;

namespace CodeBase.Presentation.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;

        protected override Type Window => typeof(SignInView);

        public override void InvokeOpen()
        {
            
        }

        public override void InvokeClose()
        {
        }
    }
}