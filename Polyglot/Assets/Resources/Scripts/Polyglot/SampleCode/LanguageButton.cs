using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AGAC.Polyglot.Sample
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public class LanguageButton : MonoBehaviour
    {

        [SerializeField]
        private string language;

        public void ChangeLanguage() 
        {
            LanguageSelector.Instance.ChangeLanguage(language);
        }
    }
}