using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AGAC.Polyglot.Sample
{
    [CustomEditor(typeof(LanguageButton))]
    public class LanguageButtonEditor : Editor
    {
        private void OnEnable()
        {
            language = serializedObject.FindProperty("language");
            Languages = PG_Manager.Languages;
            for (int option = 0; option < Languages.Count; ++option)
                if (Languages[option].Equals(language))
                    selectedOption = option;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            GUILayout.Space(10);
            selectedOption = EditorGUILayout.Popup(new GUIContent("Language:"),selectedOption, Languages.ToArray());
            language.stringValue = Languages[selectedOption];
            GUILayout.Space(10);
            serializedObject.ApplyModifiedProperties();
        }

        private SerializedProperty language;
        private int selectedOption = 0;
        private List<string> Languages;
    }
}