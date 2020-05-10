using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGAC.Polyglot.Tools 
{
    public class PG_Data : ScriptableObject
    {
        public PG_Data(int selected, List<string>languages) 
        {
            this.languages = languages;
            this.selectedLanguage = selected;
        }

        public int selectedLanguage;
        public List<string> languages;
    }
}