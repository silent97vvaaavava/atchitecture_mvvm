using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.MVVM.View;
using Core.MVVM.ViewModel;
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
        [SerializeField] 
        [Inherits(typeof(IExitableState))]
        private TypeReference _stateToGo;

        [SerializeField] private TMP_Text _coinsCounter;
        [SerializeField] private TMP_Text _crystalsCounter;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        [Inject]
        protected override void Construct(MainMenuViewModel viewModel)
        {
            base.Construct(viewModel);

            _viewModel.OnCoinsChanged += UpdateCoinsText;
            _viewModel.OnCrystalsChanged += UpdateCrystalsText;

            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

        //protected override void Construct(IProviderGet<IViewModel> provider)
        //{
        //    base.Construct(provider);

        //    _viewModel.OnCoinsChanged += UpdateCoinsText;
        //    _viewModel.OnCrystalsChanged += UpdateCrystalsText;

        //    _playButton.onClick.AddListener(OnPlayButtonClicked);
        //    _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        //}

        private void UpdateCoinsText(string amount) => _coinsCounter.text = amount;
        private void UpdateCrystalsText(string amount) => _crystalsCounter.text = amount;

        private void OnPlayButtonClicked()
        {
            _viewModel.InvokeOpen(_stateToGo.Type);
        }

        private void OnSettingsButtonClicked()
        {
            //TODO Команда view-model открыть настроечкм
        }
    }
}