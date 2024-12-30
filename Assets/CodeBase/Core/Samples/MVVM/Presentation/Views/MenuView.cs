using Core.MVVM.View;
using Core.Samples.MVVM.Presentation.ViewModels;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Samples.MVVM.Presentation.Views
{
    public class MenuView : AbstractPayloadView<MenuViewModel>
    {
        [SerializeField] private Button _changeSceneButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _anotherButton;

        public override void Construct(MenuViewModel viewModel)
        {
            base.Construct(viewModel); 
            _settingsButton.onClick.AddListener(_viewModel.OnOpenSettings);
        }

        protected override void OnBeforeDestroy()
        {
            base.OnBeforeDestroy();

            _settingsButton.onClick.RemoveListener(_viewModel.OnOpenSettings);
        }
    }
}