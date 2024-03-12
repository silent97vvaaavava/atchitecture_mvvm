using System;
using CodeBase.Infrastructure;
using TMPro;
using UnityEngine;
// using DG.Tweening;

namespace CodeBase.Presentation.Views
{
    public class CurtainView : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private float _durationCurtain;
        [SerializeField] private TMP_Text _loadingText;
        [SerializeField] private CanvasGroup _canvasGroup;

        public IProgress<int> Progress { get; private set; }

        private void Awake()
        {
            Progress = new Progress<int>(UpdateProgress);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void UpdateProgress(int percentage)
        {
            Debug.Log($"Curtain work {percentage}");
            if(!gameObject.activeSelf)
                gameObject.SetActive(true);
            
            _loadingText.SetText($"Loading... {percentage}%");
            
            if(percentage == 100) // ToDo when loading end dont hide curtain - hide only when change state  
                gameObject.SetActive(false);
        }

        public void Hide()
        {
            // _canvasGroup
            //     .DOFade(0, _durationCurtain)
            //     .OnKill(() =>
            //     {
            //         gameObject.SetActive(false);
            //         _canvasGroup.alpha = 1;
            //     });
        }
    }
}