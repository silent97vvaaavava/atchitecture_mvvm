using CodeBase.Infrastructure.Providers;
using CodeBase.Presentation.ViewModels;
using UnityEngine;

namespace CodeBase.Presentation.Views
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public abstract class ViewBase<TViewModel> : MonoBehaviour, IView
    where TViewModel : class, IViewModel
    {
        protected TViewModel _viewModel;
        
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        public Canvas CanvasElement 
        {
            get
            {
                if (_canvas == null)
                    TryGetComponent(out _canvas);
                return _canvas;
            }
        }

        public CanvasGroup CanvasGroupElement 
        {
            get
            {
                if (_canvasGroup == null)
                    TryGetComponent(out _canvasGroup);
                return _canvasGroup;
            }
        }

        protected abstract void Construct(ViewModelProvider provider);

        public virtual void Show()
        {
            CanvasGroupElement.alpha = 0;
            CanvasGroupElement.interactable = true;
            CanvasGroupElement.blocksRaycasts = true;
            CanvasElement.enabled = true;
        }

        public virtual void Hide()
        {
            CanvasGroupElement.alpha = 0;
            CanvasGroupElement.interactable = false;
            CanvasGroupElement.blocksRaycasts = false;
            CanvasElement.enabled = false;
        }
    }
}