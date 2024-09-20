using _Project.Runtime.Scripts.Utilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace _Project.Editor.Inspectors
{
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>), true)]
    public class SerializableDictionaryPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            base.GetPropertyHeight(property, label);
            return 320.0f;
        }
    }
}
