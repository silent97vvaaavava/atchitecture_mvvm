using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.MVVM.View
{
    [RequireComponent(typeof(Canvas), typeof(CanvasGroup))]
    public abstract class AbstractView : MonoBehaviour, IView
    {
        public UnityEvent<Action> OnAnimationShow = new UnityEvent<Action>();
        public UnityEvent<Action> OnAnimationHide = new UnityEvent<Action>();
        
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

        public virtual void Show()
        {
            if(OnAnimationShow.GetPersistentEventCount() > 0)
                OnAnimationShow?.Invoke(() =>  SetActive(true));
            else 
                SetActive(true);
        }

        public void Hide()
        {
            if(OnAnimationHide.GetPersistentEventCount() > 0)
                OnAnimationHide?.Invoke(() =>  SetActive(false));
            else 
                SetActive(false);
        }
        
        private void SetActive(bool isActive)
        {
            CanvasGroupElement.alpha = isActive ? 1 : 0;
            CanvasElement.enabled = isActive;
            CanvasGroupElement.blocksRaycasts = isActive;
            CanvasGroupElement.interactable = isActive;
        }
    }
}