using CodeBase.Presentation.ViewModels;

namespace CodeBase.Infrastructure.Providers
{
    public interface IViewModelProvider : 
        IProviderGet<IViewModel>, 
        IProviderSet<IViewModel> 
    {
    }
}