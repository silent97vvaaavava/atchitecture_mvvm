using Core.MVVM.View;
using Sample.MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sample.MVVM.View
{
    public class MainMenuView : BaseView<MainMenuViewModel>
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        [Inject]
        protected override void Construct(MainMenuViewModel viewModel)
        {
            base.Construct(viewModel);
        }

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

        private void OnPlayButtonClicked() => _viewModel.SwitchToState();

        private void OnSettingsButtonClicked() => _viewModel.OpenSettings();
    }
}