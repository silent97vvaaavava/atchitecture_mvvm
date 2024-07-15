using System;
using Core.MVVM.ViewModel;
using Core.MVVM.WindowFsm;
using Training.MVVM.Model;
using Training.MVVM.View;

namespace Training.MVVM.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly SettingsModel _model;
        private readonly SaveModel _saveModel;
        protected override Type Window => typeof(SettingsView);

        public event Action<bool> OnSoundChanged;
        public event Action<bool> OnMusicChanged;

        public SettingsViewModel(IWindowFsm windowFsm, SettingsModel model, SaveModel saveModel) : base(windowFsm)
        {
            _model = model;
            _saveModel = saveModel;
            _model.OnSoundChanged += HandleSoundChanged;
            _model.OnMusicChanged += HandleMusicChanged;
        }

        public override void InvokeOpen()
        {
            LoadSettings();
        }

        public override void InvokeClose()
        {
            SaveSettings();
            _windowFsm.CloseWindow(Window);
        }

        public void LoadSettings()
        {
            var settingsData = _saveModel.Load().SettingsData;
            _model.LoadSettings(settingsData);
        }

        public void SaveSettings()
        {
            var settingsData = _model.GetSettingsData();
            var saveData = _saveModel.Load();
            saveData.SettingsData = settingsData;
            _saveModel.Save(saveData);
        }

        public void SetSound(bool isOn)
        {
            _model.SetSound(isOn);
        }

        public void SetMusic(bool isOn)
        {
            _model.SetMusic(isOn);
        }

        private void HandleSoundChanged(bool isOn)
        {
            OnSoundChanged?.Invoke(isOn);
        }

        private void HandleMusicChanged(bool isOn)
        {
            OnMusicChanged?.Invoke(isOn);
        }
    }
}
