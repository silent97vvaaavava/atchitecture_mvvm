using CodeBase.Presentation.ViewModels;
using Zenject;

namespace CodeBase.Infrastructure.Factories
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