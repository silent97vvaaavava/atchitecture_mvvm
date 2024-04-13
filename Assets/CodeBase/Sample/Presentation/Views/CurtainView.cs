using Core.MVVM.View;
using Sample.Presentation.ViewModels;
using TMPro;
using UnityEngine;

namespace Sample.Presentation.Views
{
    public class CurtainView : BaseView<CurtainViewModel>
    {
        [SerializeField] private TMP_Text _loadingText;

        public void UpdateProgress(int percentage)
        {
            _loadingText.SetText($"Loading... {percentage}%");
        }
        
        private void UpdateText(int count)
        {
            
        }
    }
}