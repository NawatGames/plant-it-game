﻿using System;

namespace InventorySystem.NewInventorySystem
{
    [Serializable]
    public class ListPairKeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public ListPairKeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
