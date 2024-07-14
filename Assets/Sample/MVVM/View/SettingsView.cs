using Core.MVVM.View;
using Sample.MVVM.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sample.MVVM.View
{
    public class SettingsView : BaseView<SettingsViewModel>
    {
        private const string SOUND = "Sound";
        private const string MUSIC = "MUSIC";

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

            if (PlayerPrefs.HasKey(SOUND))
            {
                bool isOn = PlayerPrefs.GetInt(SOUND) == 1;
                _soundToggle.isOn = isOn;
            }

            if (PlayerPrefs.HasKey(MUSIC))
            {
                bool isOn = PlayerPrefs.GetInt(MUSIC) == 1;
                _musicToggle.isOn = isOn;
            }
        }

        private void OnClickSound(bool isOn)
        {
            _soundToggle.graphic.color = isOn ? Color.white : Color.clear;
            PlayerPrefs.SetInt(SOUND, isOn ? 1 : 0);
        }
        
        private void OnClickMusic(bool isOn)
        {
            _musicToggle.graphic.color = isOn ? Color.white : Color.clear;
            PlayerPrefs.SetInt(MUSIC, isOn ? 1 : 0);
        }
    }
}