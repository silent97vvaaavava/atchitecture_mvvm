using UnityEngine;
using UnityEngine.UI;

namespace Training.MVVM.View
{
    public class SettingsView : MonoBehaviour
    {
        private const string SOUND = "Sound";
        private const string MUSIC = "MUSIC";

        [SerializeField] private Button _closeButton;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Toggle _musicToggle;

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnClose);
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

        private void OnClose()
        {
            gameObject.SetActive(false);
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