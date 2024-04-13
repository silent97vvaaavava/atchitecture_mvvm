using System;
using DG.Tweening;
using UnityEngine;

namespace Core.MVVM.Elements
{
    public abstract class BaseAnimationElement : MonoBehaviour, IAnimationElement
    {
        [SerializeField] protected float _delay;
        [SerializeField] protected float _durration;

        protected Sequence _sequence;
        
        private RectTransform _rect;
        
        protected RectTransform Rect
        {
            get
            {
                if (_rect == null)
                    TryGetComponent(out _rect);
                return _rect;
            }
        }

        private void Awake()
        {
            
        }

        private void OnDisable()
        {
            _sequence.Kill();
        }

        public abstract void Show(Action callback);
        public abstract void Hide(Action callback);
    }
}