using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.MVVM.View;
using Core.MVVM.ViewModel;
using System;
using TMPro;
using Training.MVVM.ViewModel;
using TypeReferences;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Training.MVVM.View
{
    public class MainMenuView : BaseView<MainMenuViewModel>
    {
        [SerializeField] private TMP_Text _coinsCounter;
        [SerializeField] private TMP_Text _crystalsCounter;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _ShopButton;
        [SerializeField] private Button _settingsButton;

        [Inject]
        protected override void Construct(MainMenuViewModel viewModel)
        {
            base.Construct(viewModel);

            _viewModel.OnCoinsChanged += UpdateCoinsText;
            _viewModel.OnCrystalsChanged += UpdateCrystalsText;

            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _ShopButton.onClick.AddListener(OnShopButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

        private void UpdateCoinsText(string amount) => _coinsCounter.text = amount;
        private void UpdateCrystalsText(string amount) => _crystalsCounter.text = amount;

        private void OnPlayButtonClicked()
        {
            _viewModel.SwitchToState();
        }

        private void OnShopButtonClicked()
        {
            _viewModel.OpenShop();
        }

        private void OnSettingsButtonClicked()
        {
            _viewModel.OpenSettings();
        }
    }
}