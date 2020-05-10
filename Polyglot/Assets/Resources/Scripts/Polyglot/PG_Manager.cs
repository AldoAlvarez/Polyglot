using AGAC.General;
using AGAC.Polyglot.Tools;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AGAC.Polyglot
{
    public static class PG_Manager
    {
        #region VARUABLES
        private static List<string>languages;
        private static int currentLanguageIndex = 0;
        private static PG_Data languageAsset;
        public static List<string> Languages
        {
            get
            {
                LoadLanguages(); return languages;
            }
        }
        public static string CurrentLanguage
        {
            get
            {
                return Languages[currentLanguageIndex];
            }
        }
        #endregion

        public static void SetLanguage(string language)
        {
            if (!Languages.Contains(language)) return;
            SelectLanguage(language);
            languageAsset.selectedLanguage = currentLanguageIndex;
            AssetDatabase.SaveAssets();
        }

        #region PRIVATE METHODS
        private static void LoadLanguages() 
        {
            if (languages != null) return;
            languageAsset = PG_FileManager.GetSavedData();
            SetVariables(languageAsset);
        }
        private static void SetVariables(PG_Data data) 
        {
            languages = data.languages;
            currentLanguageIndex = data.selectedLanguage;
            CheckForMinimumLanguages();
            CheckForOutboundsIndex();
        }
        private static void SelectLanguage(string language) 
        {
            for (int langIndex = 0; langIndex < languages.Count; ++langIndex)
                if (languages[langIndex].Equals(language))
                    currentLanguageIndex = langIndex;
        }
        private static void CheckForMinimumLanguages() 
        {
            if (languages.Count <= 0) 
            {
                languages.Add("Spanish");
                languageAsset.languages = languages;
                AssetDatabase.SaveAssets();
            }
        }
        private static void CheckForOutboundsIndex() 
        {
            if (currentLanguageIndex < 0)
                currentLanguageIndex = 0;
            else if (currentLanguageIndex >= languages.Count) 
                currentLanguageIndex = languages.Count - 1;
        }
        #endregion
    }
}