using Core.MVVM.ViewModel;
using UnityEngine;

namespace Core.MVVM.View
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public abstract class AbstractPayloadView<TViewModel> : AbstractView
    where TViewModel : class, IViewModel
    {
        protected TViewModel _viewModel;
        
        protected virtual void Construct(TViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.InvokedOpen += Show;
            _viewModel.InvokedClose += Hide; 
        }

        private void OnDestroy()
        {
            _viewModel.InvokedOpen -= Show;
            _viewModel.InvokedClose -= Hide;
        }
    }
}