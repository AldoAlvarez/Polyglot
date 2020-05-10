using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AGAC.Polyglot.Tools;
using AGAC.Polyglot;

namespace CustomEditors.Polyglot
{
    [CustomEditor(typeof(PG_ElementsContainer))]
    [CanEditMultipleObjects]
    public class PG_ElementsContainerEditor : Editor
    {
        private void OnEnable()
        {
            SetVariables();
        }
        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(type);
            GUILayout.Space(12);
            ElementTypes e_type = (ElementTypes)type.intValue;
            GetDictionaryEditor(e_type).OnInspectorGUI();
            serializedObject.ApplyModifiedProperties();
        }

        #region VARIABLES
        private PG_ElementsContainer container;
        private SerializedProperty type;
        private SerializedProperty texts;
        private SerializedProperty images;
        private SerializedProperty audioClips;
        private SerializedProperty videoClips;

        private LanguageDictionaryEditor[] DictionaryEditors;
        #endregion

        #region PRIVATE METHODS

        private LanguageDictionaryEditor GetDictionaryEditor(ElementTypes _type) 
        {
            int editor = (int)_type;
            if (editor < 0 || editor >= DictionaryEditors.Length) 
                return null;
            return DictionaryEditors[editor];
        }

        #region initialize
        private void SetVariables() 
        {
            container = (PG_ElementsContainer)target;
            SetSerilizedProperties();
            InitializeDictionaries();
            CreateDictionariesEditors();
            CallInitializationMethodsOfDictionaries();
        }
        private void SetSerilizedProperties() 
        {
            type = serializedObject.FindProperty("type");
            texts = serializedObject.FindProperty("texts");
            images = serializedObject.FindProperty("images");
            audioClips = serializedObject.FindProperty("audioClips");
            videoClips = serializedObject.FindProperty("videoClips");
        }
        private void InitializeDictionaries() 
        {
            container.texts.LanguagesToKeys();
            container.images.LanguagesToKeys();
            container.audioClips.LanguagesToKeys();
            container.videoClips.LanguagesToKeys();
        }
        private void CreateDictionariesEditors() 
        {
            DictionaryEditors = new LanguageDictionaryEditor[(int)ElementTypes.count];
            DictionaryEditors[(int)ElementTypes.TEXT] = new LanguageDictionaryEditor(texts);
            DictionaryEditors[(int)ElementTypes.IMAGE] = new LanguageDictionaryEditor(images);
            DictionaryEditors[(int)ElementTypes.AUDIO] = new LanguageDictionaryEditor(audioClips);
            DictionaryEditors[(int)ElementTypes.VIDEO] = new LanguageDictionaryEditor(videoClips);
        }
        private void CallInitializationMethodsOfDictionaries() 
        {
            for (int editor = 0; editor < DictionaryEditors.Length; ++editor)
                DictionaryEditors[editor].OnEnable();
        }
        #endregion
        #endregion
    }
}