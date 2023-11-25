using CodeBase.Presentation.ViewModels;

namespace CodeBase.Infrastructure.Providers
{
    public class ViewModelProvider : IProvider<IViewModel>
    {
        public TValue Get<TValue>() where TValue : class, IViewModel
        {
            throw new System.NotImplementedException();
        }
    }
}