using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.MVVM.View;
using Core.MVVM.ViewModel;
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
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        [Inject]
        protected override void Construct(IProviderGet<IViewModel> provider)
        {
            base.Construct(provider);
            
            Debug.Log("ПОДПИСАЛИ МЕТОД НА КНОПКУ, кнопка - " + _playButton + "StateToGo - " + _stateToGo);
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        }

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