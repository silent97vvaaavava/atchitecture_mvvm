using System;
using Core.Infrastructure.GameFsm;
using Core.MVVM.Model;

namespace Training.MVVM.Model
{
    public class MainMenuModel : IModel
    {
        private readonly IGameFsm _gameFsm;
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

        public MainMenuModel(IGameFsm gameFsm) 
        {
            _gameFsm = gameFsm;
        }

        public void AddCoins(int amount) => CurrentCoins += amount;
        public void AddCrystals(int amount) => CurrentCrystals += amount;
        public void SubtractCoins(int amount) => CurrentCoins -= amount;
        public void SubtractCrystals(int amount) => CurrentCrystals -= amount;

        public void SwitchToState(Type state) //Go to next state
        {
            _gameFsm.Enter(state);
        }
    }
}