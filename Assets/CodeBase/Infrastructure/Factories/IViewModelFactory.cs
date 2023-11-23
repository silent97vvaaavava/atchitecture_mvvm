using CodeBase.Presentation.ViewModels;

namespace CodeBase.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        TViewModel Create<TViewModel>()
            where TViewModel : class, IViewModel;
    }
}