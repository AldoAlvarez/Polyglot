using System;
using System.Collections.Generic;
using UnityEngine;

namespace AGAC.General
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue>
    {
        public SerializableDictionary()
        {
            Keys = new List<TKey>();
            Values = new List<TValue>();
        }
        #region VARIABLES
        [SerializeField]
        protected List<TKey> Keys;
        [SerializeField]
        protected List<TValue> Values;
        public int size
        {
            get
            {
                return Keys.Count;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                if (hasKey(key))
                    SetValue(key, value);
            }
        }
        #endregion

        #region PUBLIC METHODS
        public void Add(TKey key, TValue value)
        {
            if (hasKey(key)) return;
            Keys.Add(key);
            Values.Add(value);
        }

        public void Remove(TKey key)
        {
            if (!hasKey(key)) return;
            for (int _key = 0; _key < Keys.Count; ++_key)
            {
                if (CompareKeys(Keys[_key], key))
                {
                    Values.RemoveAt(_key);
                    Keys.RemoveAt(_key);
                    return;
                }
            }
        }
        public void Clear() 
        {
            Keys.Clear();
            Values.Clear();
        }
        #endregion

        #region PRIVATE METHODS
        private TValue GetValue(TKey key)
        {
            for (int _key = 0; _key < Keys.Count; ++_key)
                if (CompareKeys(Keys[_key], key))
                    return Values[_key];
            return default(TValue);
        }

        private void SetValue(TKey key, TValue value)
        {
            for (int _key = 0; _key < Keys.Count; ++_key)
                if (CompareKeys(Keys[_key], key))
                    Values[_key] = value;
        }

        private bool hasKey(TKey key)
        {
            foreach (TKey _key in Keys)
                if (CompareKeys(_key, key))
                    return true;
            return false;
        }

        private bool CompareKeys(TKey key1, TKey key2)
        {
            return key1.Equals(key2);
        }
        #endregion
    }
}