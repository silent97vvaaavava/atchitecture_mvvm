using System;
using Core.Domain.Providers;
using Core.MVVM.ViewModel;
using UnityEngine;
using UnityEngine.Events;

namespace Core.MVVM.View
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public abstract class BaseView<TViewModel> : MonoBehaviour, IView
    where TViewModel : class, IViewModel
    {
        public UnityEvent<Action> OnAnimationShow = new UnityEvent<Action>();
        public UnityEvent<Action> OnAnimationHide = new UnityEvent<Action>();
        
        protected TViewModel _viewModel;
        
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        public virtual Canvas CanvasElement 
        {
            get
            {
                if (_canvas == null)
                    TryGetComponent(out _canvas);
                return _canvas;
            }
        }

        public virtual CanvasGroup CanvasGroupElement 
        {
            get
            {
                if (_canvasGroup == null)
                    TryGetComponent(out _canvasGroup);
                return _canvasGroup;
            }
        }

        protected virtual void Construct(IProviderGet<IViewModel> provider)
        {
            _viewModel = provider.Get<TViewModel>();

            _viewModel.InvokedOpen += Show;
            _viewModel.InvokedClose += Hide;
        }

        public virtual void Show()
        {
            if(OnAnimationShow.GetPersistentEventCount() > 0)
                OnAnimationShow?.Invoke(() =>  SetActive(true));
            else 
                SetActive(true);
        }

        public virtual void Hide()
        {
            if(OnAnimationHide.GetPersistentEventCount() > 0)
                OnAnimationHide?.Invoke(() =>  SetActive(false));
            else 
                SetActive(false);
        }
        
        private void SetActive(bool isActive)
        {
            Debug.Log($"active: {isActive}");
            CanvasGroupElement.alpha = isActive ? 1 : 0;
            CanvasElement.enabled = isActive;
            CanvasGroupElement.blocksRaycasts = isActive;
            CanvasGroupElement.interactable = isActive;
        }
    }
}