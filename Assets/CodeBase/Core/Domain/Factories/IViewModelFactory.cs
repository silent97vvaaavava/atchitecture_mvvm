using CodeBase.Core.MVVM.ViewModel;

namespace CodeBase.Core.Domain.Factories
{
    public interface IViewModelFactory
    {
        TViewModel Create<TViewModel>()
            where TViewModel : class, IViewModel;
    }
}