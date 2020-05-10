using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AGAC.Polyglot.Tools
{
    [CreateAssetMenu(fileName = "New Polyglot Element", menuName = "Polyglot/Element Container")]
    public class PG_ElementsContainer : ScriptableObject
    {
        public ElementTypes type = ElementTypes.TEXT;
        public TextDictionary texts = new TextDictionary();
        public ImageDictionary images = new ImageDictionary();
        public AudioDictionary audioClips = new AudioDictionary();
        public VideoDictionary videoClips = new VideoDictionary();
    }
}