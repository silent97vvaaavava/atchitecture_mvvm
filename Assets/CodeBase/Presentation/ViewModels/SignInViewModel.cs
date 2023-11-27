using System;
using CodeBase.StaticData;

namespace CodeBase.Presentation.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;

        protected override UiWindow Window => UiWindow.SignIn;

        public override void InvokeOpen()
        {
            
        }

        public override void InvokeClose()
        {
        }
    }
}