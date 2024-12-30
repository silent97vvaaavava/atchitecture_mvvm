using UnityEngine;

namespace Core.MVP.Views
{
    public class CanvasGroupView : ViewBase
    {
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }

        public void Show()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }
    }
}