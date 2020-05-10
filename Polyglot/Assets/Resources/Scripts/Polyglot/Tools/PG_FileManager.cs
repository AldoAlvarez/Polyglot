using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace AGAC.Polyglot.Tools
{
    public static class PG_FileManager
    {
        private const string AssetName = "languages";
        private const string AssetExtension = ".asset";
        private const string AssetPath = "Languages/";

        public static PG_Data GetSavedData() 
        {
            PG_Data data = LoadData();
            if (data != null)
                return data;
#if UNITY_EDITOR
            return CreateLanguagesAsset();
#else
            return GetSampleLanguagesAsset();
#endif
        }

        private static PG_Data LoadData()
        {
            string resources_path = AssetPath + AssetName;
            PG_Data data = Resources.Load<PG_Data>(resources_path);
            return data;
        }
        private static PG_Data CreateLanguagesAsset()
        {
            CreateLanguagesAssetPath();

            PG_Data newData = GetSampleLanguageAsset();
            string fullPath = "Assets/Resources/" + AssetPath + AssetName+ AssetExtension;
            AssetDatabase.CreateAsset(newData, fullPath);
            AssetDatabase.SaveAssets();

            return newData;
        }
        private static PG_Data GetSampleLanguageAsset()
        {
            List<string> sampleLanguages = new List<string>() { "Spanish", "English", "German" };
            PG_Data data = ScriptableObject.CreateInstance<PG_Data>();
            data.languages = sampleLanguages;
            data.selectedLanguage = 0;
            return  data;
        }
        private static void CreateLanguagesAssetPath() 
        {
            string path = Application.dataPath + "/Resources/" + AssetPath;
            if (Directory.Exists(path))return;
            Directory.CreateDirectory(path);
        }
    }
}
