using System.Collections.Generic;
using _Project.Runtime.Scripts.Utilities;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Editor.Inspectors
{
    [CustomPropertyDrawer(typeof(SerializableDictionary<,>), true)]
    public class SerializableDictionaryPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement container = new VisualElement();

            PropertyField keyValuePairsField = new PropertyField(property.FindPropertyRelative("_keyValuePairs"));

            container.Add(keyValuePairsField);
            
            return container;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            Rect keyValuePairsRect = new Rect(position.x, position.y, 300, position.height);

            EditorGUI.PropertyField(keyValuePairsRect, property.FindPropertyRelative("_keyValuePairs"),
                new GUIContent("Serializable Dictionary"));
            
            EditorGUI.EndProperty(); 
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            base.GetPropertyHeight(property, label);

            var targetObject = property.serializedObject.targetObject;
            var targetObjectClassType = targetObject.GetType();
            var field = targetObjectClassType.GetField(property.propertyPath);
            if (field != null)
            {
                var value = field.GetValue(targetObject);
                SerializableDictionary<object, object> serializableDictionary =
                    value as SerializableDictionary<object, object>;
                Debug.Log(serializableDictionary == null ? "NoWork" : "Work");
            }
            else
            {
                Debug.Log("Field null");
            }

            // float height = keyValuePairs.Count * EditorGUIUtility.singleLineHeight * 3f;
            
            return 300;
        }
    }
}
