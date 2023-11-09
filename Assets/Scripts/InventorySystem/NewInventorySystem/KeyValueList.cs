using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.NewInventorySystem
{
    public class KeyValueList<TKey, TValue> : MonoBehaviour
    {
        public List<ListPairKeyValue<TKey, TValue>> ListPairKeyValue = new List<ListPairKeyValue<TKey, TValue>>();

        public TValue GetValueForKey(TKey key)
        {
            foreach (var entry in ListPairKeyValue)
            {
                if (EqualityComparer<TKey>.Default.Equals(entry.Key, key))
                {
                    return entry.Value;
                }
            }
            return default(TValue);
        }
    }
}