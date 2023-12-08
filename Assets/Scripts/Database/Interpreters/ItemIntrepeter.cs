using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contents;
using UnityEngine;

namespace Database.Interpreters
{
    public class ItemIntrepeter : MonoBehaviour
    {
        public TextAsset itemDatabase;
        [SerializeField] private List<Item> items = new List<Item>();
        private void Awake()
        {
            var text = itemDatabase.text;
            var lines = text.Split('\n').ToList();
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            foreach (var line in lines)
            {
                Debug.Log(line);
                Item item = new Item(line);
                items.Add(item);
            }
        }
        
        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(item => item.itemName == itemName);
        }
    }
}