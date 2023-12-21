using UnityEngine;
using UnityEditor;

namespace InventorySystem
{
    public class MoneyDebugger : EditorWindow
    {
        private static float _amount = 100f;
        private static float _amountDisplayed = 0f;
        
        [MenuItem("Window/Money Debugger")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow<MoneyDebugger>("Money Debugger Window");
            _amountDisplayed = MoneyInterface.GetMoney();
        }
        private void OnGUI()
        {
            GUILayout.Label("Current money: " + _amountDisplayed, EditorStyles.whiteLargeLabel);
            _amount = EditorGUILayout.FloatField("Amount", _amount);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add Money"))
            {
                MoneyInterface.AddMoney(_amount);
                _amountDisplayed = MoneyInterface.GetMoney();
            }
            if (GUILayout.Button("Refresh"))
            {
                _amountDisplayed = MoneyInterface.GetMoney();
            }
            if (GUILayout.Button("Set Money"))
            {
                MoneyInterface.SetMoney(_amount);
                _amountDisplayed = MoneyInterface.GetMoney();
            }
            GUILayout.EndHorizontal();
        }
    }
}