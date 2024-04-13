using Core.MVVM.ViewModel;

namespace Core.Domain.Factories
{
    public interface IViewModelFactory
    {
        TViewModel Create<TViewModel>()
            where TViewModel : class, IViewModel;
    }
}