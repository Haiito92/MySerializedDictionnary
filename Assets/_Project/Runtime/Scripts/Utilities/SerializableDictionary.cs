using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace _Project.Runtime.Scripts.Utilities
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        [SerializeField] private List<SerializableKeyValuePair> _keyValuePairs;
        
        [Serializable]
        private struct SerializableKeyValuePair
        {
            [SerializeField] private TKey _key;
            [SerializeField] private TValue _value;

            public TKey Key => _key;
            public TValue Value
            {
                get => _value;
                set => _value = value;
            }
            
            public SerializableKeyValuePair(TKey key, TValue value)
            {
                _key = key;
                _value = value;
            }
        }
                
        public new void Add(TKey key, TValue value)
        {
            SerializableKeyValuePair newPair = new(key, value);

            if (ContainsKey(key)) Remove(key);
            
            //Add in Dictionary
            base.Add(key, value);

            //this[key] = value;
            
            //Add in List
            _keyValuePairs.Add(newPair);
        }

        public new void Remove(TKey key)
        {
            //Remove from Serialized List
            if(!TryGetValue(key, out TValue value)) return;
            
            SerializableKeyValuePair oldPair = new(key, value);
            
            _keyValuePairs.Remove(oldPair);
            
            //Remove from Dictionary
            base.Remove(key);
        }
    }
}
