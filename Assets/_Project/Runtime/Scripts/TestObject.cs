using System.Collections.Generic;
using _Project.Runtime.Scripts.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Runtime.Scripts
{
    public class TestObject : MonoBehaviour
    {
        private Dictionary<string, int> _dictionary;
        
        [SerializeField] private SerializableDictionary<string, int> _serializableDictionary;

        //Add Test
        [SerializeField] private string _stringToAdd;
        [SerializeField] private int _intToAdd;
        
        [Button]
        private void TestAddSD()
        {
            _serializableDictionary.Add(_stringToAdd, _intToAdd);
        }

        //Remove Test
        [SerializeField] private string _stringToRemove;
        
        [Button]
        private void TestRemoveSD()
        {
            _serializableDictionary.Remove(_stringToRemove);
        }
    }
}
