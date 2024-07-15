using Core.MVVM.View;
using Training.MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Training.MVVM.View
{
    public class SettingsView : BaseView<SettingsViewModel>
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Toggle _musicToggle;

        [Inject]
        protected override void Construct(SettingsViewModel viewModel)
        {
            base.Construct(viewModel);

            _closeButton.onClick.AddListener(() => _viewModel.InvokeClose());
            _soundToggle.onValueChanged.AddListener(OnClickSound);
            _musicToggle.onValueChanged.AddListener(OnClickMusic);

            _viewModel.OnSoundChanged += UpdateSoundToggle;
            _viewModel.OnMusicChanged += UpdateMusicToggle;

            _viewModel.LoadSettings();
        }

        private void OnClickSound(bool isOn) => _viewModel.SetSound(isOn);
        private void OnClickMusic(bool isOn) => _viewModel.SetMusic(isOn);

        private void UpdateSoundToggle(bool isOn)
        {
            _soundToggle.SetIsOnWithoutNotify(isOn);    
            _soundToggle.graphic.color = isOn ? Color.white : Color.clear;
        }

        private void UpdateMusicToggle(bool isOn)
        {
            _musicToggle.SetIsOnWithoutNotify(isOn); 
            _musicToggle.graphic.color = isOn ? Color.white : Color.clear;
        }
    }
}
