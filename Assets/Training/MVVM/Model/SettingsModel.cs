using Core.MVVM.Model;
using System;

namespace Training.MVVM.Model
{
    [Serializable]
    public class SettingsData
    {
        public bool Sound;
        public bool Music;
    }

    public class SettingsModel : IModel
    {
        private SettingsData _settingsData;

        public event Action<bool> OnSoundChanged;
        public event Action<bool> OnMusicChanged;

        public void LoadSettings(SettingsData settingsData)
        {
            _settingsData = settingsData;

            OnSoundChanged?.Invoke(_settingsData.Sound);
            OnMusicChanged?.Invoke(_settingsData.Music);
        }

        public SettingsData GetSettingsData()
        {
            return _settingsData;
        }

        public void SetSound(bool isOn)
        {
            _settingsData.Sound = isOn;
            OnSoundChanged?.Invoke(isOn);
        }

        public void SetMusic(bool isOn)
        {
            _settingsData.Music = isOn;
            OnMusicChanged?.Invoke(isOn);
        }
    }
}
