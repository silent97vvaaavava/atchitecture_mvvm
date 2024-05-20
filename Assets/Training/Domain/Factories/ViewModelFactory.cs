using Core.Domain.Factories;
using Core.MVVM.ViewModel;
using Zenject;

namespace Training.Domain.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly DiContainer _diContainer;

        public ViewModelFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public TViewModel Create<TViewModel>() where TViewModel : class, IViewModel
        {
            return _diContainer.Instantiate<TViewModel>();
        }
    }
}