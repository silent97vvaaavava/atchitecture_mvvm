using CodeBase.Core.MVVM.ViewModel;

namespace CodeBase.Core.Domain.Providers
{
    public interface IViewModelProvider : 
        IProviderGet<IViewModel>, 
        IProviderSet<IViewModel> 
    {
    }
}