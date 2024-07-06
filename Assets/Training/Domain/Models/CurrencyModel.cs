using System;
using UnityEngine;

namespace Training.Domain.Models
{
    public class CurrencyModel : MonoBehaviour
    {
        public int Coins { get; private set; }
        public int Crystals { get; private set; }

        public event Action<int> OnCoinsChanged;
        public event Action<int> OnCrystalsChanged;

        public void AddCoins(int amount)
        {
            Coins += amount;
            OnCoinsChanged?.Invoke(Coins);
        }

        public void SubtractCoins(int amount)
        {
            Coins -= amount;
            OnCoinsChanged?.Invoke(Coins);
        }

        public void AddCrystals(int amount)
        {
            Crystals += amount;
            OnCrystalsChanged?.Invoke(Crystals);
        }

        public void SubtractCrystals(int amount)
        {
            Crystals -= amount;
            OnCrystalsChanged?.Invoke(Crystals);
        }
    }
}
