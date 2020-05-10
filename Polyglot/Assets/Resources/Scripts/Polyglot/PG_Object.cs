using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using AGAC.Polyglot.Tools;

namespace AGAC.Polyglot
{
    [DisallowMultipleComponent]
    public class PG_Object : MonoBehaviour
    {
        #region VARIABLES
        [SerializeField]
        private PG_ElementsContainer Elements;
        #endregion

        #region PUBLIC METHODS
        public void LoadElement()
        {
            if (Elements == null) return;
            LoadElementDataToComponent(); 
        }
        #endregion

        #region PRIVATE METHODS
        private void LoadElementDataToComponent() 
        {
            AddNeccesarryComponent(Elements.type);
            string language = PG_Manager.CurrentLanguage;
            AssignLanguageDataToComponent(language);
        }
        private void AddNeccesarryComponent(ElementTypes type)
        {
            Type component_type = GetComponentType(type);
            if (!hasComponent(component_type))
                AddComponent(component_type);
        }
        private void AssignLanguageDataToComponent(string language)
        {
            switch (Elements.type)
            {
                case ElementTypes.TEXT: GetComponent<Text>().text = Elements.texts[language]; return;
                case ElementTypes.IMAGE: GetComponent<Image>().sprite = Elements.images[language]; return;
                case ElementTypes.AUDIO: GetComponent<AudioSource>().clip = Elements.audioClips[language]; return;
                case ElementTypes.VIDEO: GetComponent<VideoPlayer>().clip = Elements.videoClips[language]; return;
                default: return;
            }
        }
        private Type GetComponentType(ElementTypes type) 
        {
            switch (type)
            {
                case ElementTypes.TEXT: return typeof(Text); 
                case ElementTypes.IMAGE: return typeof(Image); 
                case ElementTypes.AUDIO: return typeof(AudioSource); 
                case ElementTypes.VIDEO: return typeof(VideoPlayer); 
                default: return default;
            }
        }
        private void AddComponent(Type type)
        {
            gameObject.AddComponent(type);
        }
        private bool hasComponent(Type type)
        {
            return gameObject.GetComponent(type) != null;
        }
        #endregion
    }
}