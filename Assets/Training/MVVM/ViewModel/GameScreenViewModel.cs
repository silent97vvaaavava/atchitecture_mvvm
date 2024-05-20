using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.MVVM.View;

namespace Training.MVVM.ViewModel
{
    public class GameScreenViewModel : BaseViewModel
    {
        private readonly IWindowResolve _windowResolve;

        public GameScreenViewModel(IWindowFsm windowFsm, IWindowResolve windowResolve) : base(windowFsm)
        {
            _windowResolve = windowResolve;
            RegisterView();
        }

        protected override Type Window => typeof(GameScreenView);

        private void RegisterView()
        {
            _windowResolve.Set<GameScreenView>();
        }

        public override void InvokeOpen()
        {
            Console.WriteLine("GameScreenViewModel: Открытие главного меню");
            _windowFsm.OpenWindow(Window); 
        }

        public override void InvokeClose()
        {
            Console.WriteLine("GameScreenViewModel: Закрытие главного меню");
            _windowFsm.CloseWindow(Window); 
        }
    }
}