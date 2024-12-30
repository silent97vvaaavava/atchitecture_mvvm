using Core.MVVM.ViewModel;
using UnityEngine;

namespace Core.MVVM.View
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public abstract class AbstractPayloadView<TViewModel> : AbstractView
    where TViewModel : class, IViewModel
    {
        protected TViewModel _viewModel;
        
        public virtual void Construct(TViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.InvokedOpen += Show;
            _viewModel.InvokedClose += Hide; 
            
            _viewModel.CheckInvoked();
        }

        protected virtual void OnBeforeDestroy() { }
        
        private void OnDestroy()
        {
            if(_viewModel == null)
                return;
            
            _viewModel.InvokedOpen -= Show;
            _viewModel.InvokedClose -= Hide;
            
            OnBeforeDestroy();
        }
    }
}