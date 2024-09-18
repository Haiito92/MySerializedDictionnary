using _Project.Runtime.Scripts.Utilities;
using UnityEditor;

namespace _Project.Editor.Inspectors
{
    [CustomEditor(typeof(SerializableDictionary<,>), true)]
    public class SerializableDictionaryEditor : UnityEditor.Editor
    {
        private SerializedProperty _keyValuePairsProperty;
        
        private void OnEnable()
        {
            _keyValuePairsProperty = serializedObject.FindProperty("_keyValuePairs");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            //base.OnInspectorGUI();

            EditorGUILayout.LabelField("LIST", EditorStyles.boldLabel);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
