using AGAC.General;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace AGAC.Polyglot.Tools
{
    [Serializable]
    public class LanguageDictionary <TValue> : SerializableDictionary<string, TValue>
    {
        public void LanguagesToKeys()
        {
            RemoveKeysThatAreNotLanguages();
            if (Keys.Count != PG_Manager.Languages.Count)
                AddLanguagesToKeys();
        }

        private void RemoveKeysThatAreNotLanguages() 
        {
            List<string> languages = PG_Manager.Languages;
            foreach (string key in Keys) 
                if (!languages.Contains(key))
                    Remove(key);
        }
        private void AddLanguagesToKeys() 
        {
            List<string> languages = PG_Manager.Languages;
            foreach (string language in languages)
                if (!Keys.Contains(language))
                    Add(language, default);
        }
    }

    [Serializable]
    public class TextDictionary : LanguageDictionary<string> { }
    [Serializable]
    public class ImageDictionary : LanguageDictionary<Sprite> { }
    [Serializable]
    public class AudioDictionary : LanguageDictionary<AudioClip> { }
    [Serializable]
    public class VideoDictionary : LanguageDictionary<VideoClip> { }
}