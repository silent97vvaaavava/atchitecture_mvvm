using System;
using Core.MVVM.Elements;
using DG.Tweening;
using UnityEngine;

namespace Sample.Scripts.MVVM.Animation
{
    public class AnimationElement : MonoBehaviour, IAnimationElement
    {
        [SerializeField] private float _duration = 1;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private Tween _tween;
        
        public void Show(Action callback)
        {
            if(_tween.IsActive())
                _tween.Kill();

            _tween = _canvasGroup
                .DOFade(1, _duration)
                .OnKill(() =>
                {
                    callback?.Invoke();
                });
        }

        public void Hide(Action callback)
        {
            if(_tween.IsActive())
                _tween.Kill();

            _tween = _canvasGroup
                .DOFade(0, _duration)
                .OnStart(() => callback?.Invoke())
                .OnKill(() =>
                {
                    _canvasGroup.alpha = 0;
                });
        }
    }
}