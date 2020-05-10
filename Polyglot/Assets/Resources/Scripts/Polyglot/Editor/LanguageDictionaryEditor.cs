using UnityEngine;
using UnityEditor;

namespace CustomEditors.Polyglot
{
    public sealed class LanguageDictionaryEditor
    {
        public LanguageDictionaryEditor(SerializedProperty dictionary) 
        {
            Dictionaty = dictionary;
        }

        #region VARIABLES
        private SerializedProperty Keys;
        private SerializedProperty Values;
        private SerializedProperty Dictionaty;
        private GUIStyle wrapedTextArea;
        #endregion

        #region PUBLIC METHODS
        public void OnEnable() 
        {
            SetVariables();
        }
        public void OnInspectorGUI() 
        {
            float labelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 100;
            for (int key = 0; key < Keys.arraySize; ++key) 
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(Keys.GetArrayElementAtIndex(key).stringValue, GUILayout.MaxWidth(100));
                SerializedProperty value = Values.GetArrayElementAtIndex(key);
                if (value.type == "string")
                    value.stringValue = EditorGUILayout.TextArea(value.stringValue, wrapedTextArea, GUILayout.Height(42), GUILayout.ExpandHeight(false));
                else
                    EditorGUILayout.PropertyField(value, GUIContent.none);
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(10);
            }
            EditorGUIUtility.labelWidth = labelWidth;
        }
        #endregion

        #region PRIVATE METHODS
        private void SetVariables() 
        {
            Keys = Dictionaty.FindPropertyRelative("Keys");
            Values = Dictionaty.FindPropertyRelative("Values");
            wrapedTextArea = new GUIStyle(EditorStyles.textArea);
            wrapedTextArea.wordWrap = true;
        }
        #endregion
    }
}