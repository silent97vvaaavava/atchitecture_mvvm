using Core.Domain.Providers;
using Core.MVVM.ViewModel;
using UnityEngine;

namespace Core.MVVM.View
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public abstract class AbstractPayloadView<TViewModel> : AbstractView
    where TViewModel : class, IViewModel
    {
        protected TViewModel _viewModel;
        
        protected override void Construct(IProviderGet<IViewModel> provider)
        {
            _viewModel = provider.Get<TViewModel>();

            _viewModel.InvokedOpen += Show;
            _viewModel.InvokedClose += Hide; 
        }
    }
}