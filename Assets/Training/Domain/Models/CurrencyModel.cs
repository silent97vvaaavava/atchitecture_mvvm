using Core.MVVM.Model;
using System;

namespace Training.MVVM.Model
{
    public class CurrencyModel : IModel
    {
        private int _currentCoins = 100;
        private int _currentCrystals = 50;

        public event Action<int> OnCoinsChanged;
        public event Action<int> OnCrystalsChanged;

        public int CurrentCoins
        {
            get => _currentCoins;
            private set
            {
                _currentCoins = value;
                OnCoinsChanged?.Invoke(_currentCoins);
            }
        }
        public int CurrentCrystals
        {
            get => _currentCrystals;
            private set
            {
                _currentCrystals = value;
                OnCrystalsChanged?.Invoke(_currentCrystals);
            }
        }

        public void AddCoins(int amount) => CurrentCoins += amount;
        public void AddCrystals(int amount) => CurrentCrystals += amount;
        public void SubtractCoins(int amount) => CurrentCoins -= amount;
        public void SubtractCrystals(int amount) => CurrentCrystals -= amount;

        public void LoadData(SaveData data)
        {
            CurrentCoins = data.Coins;
            CurrentCrystals = data.Crystals;
        }

        public SaveData GetSaveData()
        {
            return new SaveData
            {
                Coins = CurrentCoins,
                Crystals = CurrentCrystals
            };
        }
    }
}
