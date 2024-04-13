using Core.MVVM.ViewModel;

namespace Core.Domain.Providers
{
    public interface IViewModelProvider : 
        IProviderGet<IViewModel>, 
        IProviderSet<IViewModel> 
    {
    }
}