using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem
{
    public static class MoneyInterface
    {
        private static string _playerMoneyKey = "playerMoney";
        
        public static void SetMoney(float amount = 0f)
        {
            PlayerPrefs.SetFloat(_playerMoneyKey, amount);
        }

        public static float GetMoney()
        {
            return PlayerPrefs.GetFloat(_playerMoneyKey);
        }
        
        public static void AddMoney(float amount = 0f)
        {
            float newAmount = GetMoney() + amount;
            PlayerPrefs.SetFloat(_playerMoneyKey, newAmount);
        }
    }
}