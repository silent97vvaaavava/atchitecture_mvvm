using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.MVVM.View;

namespace Training.MVVM.ViewModel
{
    public class MainMenuScreenViewModel : BaseViewModel
    {
        private readonly IWindowResolve _windowResolve;

        public MainMenuScreenViewModel(IWindowFsm windowFsm, IWindowResolve windowResolve) : base(windowFsm)
        {
            _windowResolve = windowResolve;
            RegisterView();
        }

        protected override Type Window => typeof(MainMenuScreenView);

        private void RegisterView()
        {
            _windowResolve.Set<MainMenuScreenView>();
        }

        public override void InvokeOpen()
        {
            Console.WriteLine("MainMenuScreenViewModel: Открытие главного меню");
            _windowFsm.OpenWindow(Window); 
        }

        public override void InvokeClose()
        {
            Console.WriteLine("MainMenuScreenViewModel: Закрытие главного меню");
            _windowFsm.CloseWindow(Window); 
        }
    }
}