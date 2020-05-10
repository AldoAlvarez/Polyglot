using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AGAC.Polyglot;
using AGAC.General;

namespace AGAC.Polyglot.Sample
{
    [DisallowMultipleComponent]
    public class LanguageSelector : MonoBehaviour
    {
        private void Start()
        {
            polyglotObjects = GameObject.FindObjectsOfType<PG_Object>();
            ChangeLanguageOfObjects();
        }

        #region VARIABLES
        private PG_Object[] polyglotObjects;
        private static LanguageSelector instance;
        public static LanguageSelector Instance
        {
            get
            {
                SetInstance(); return instance;
            }
        }
        #endregion

        #region PUBLIC METHODS
        public void ChangeLanguage(string language)
        {
            if (language == PG_Manager.CurrentLanguage) return;
            PG_Manager.SetLanguage(language);
            ChangeLanguageOfObjects();
        }
        #endregion

        #region PRIVATE METHODS
        private static void SetInstance()
        {
            if (instance != null) return;
            instance = GeneralMethods.GetInstance<LanguageSelector>("Language Selector");
        }

        private void ChangeLanguageOfObjects()
        {
            foreach (PG_Object obj in polyglotObjects)
                obj.LoadElement();
        }
        #endregion
    }
}