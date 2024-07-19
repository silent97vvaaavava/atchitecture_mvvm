using Core.MVVM.View;
using Sample.MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sample.MVVM.View
{
    public class GameplayView : AbstractPayloadView<GameplayViewModel>
    {
        [SerializeField] private Button _backButton;
        
        [Inject]
        protected override void Construct(GameplayViewModel viewModel)
        {
            base.Construct(viewModel);
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            _viewModel.SwitchToState();
        }
    }
}