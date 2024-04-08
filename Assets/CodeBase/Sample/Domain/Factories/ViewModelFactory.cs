using CodeBase.Core.Domain.Factories;
using CodeBase.Core.MVVM.ViewModel;
using Zenject;

namespace CodeBase.Sample.Domain.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly DiContainer _container;

        public ViewModelFactory(DiContainer container)
        {
            _container = container;
        }

        public TViewModel Create<TViewModel>() 
            where TViewModel : class, IViewModel
        {
            return _container.Instantiate<TViewModel>();
        }
    }
}