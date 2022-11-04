using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AdventOfCode.AOCClient
{
    [CreateAssetMenu]
    public class AdventOfCodeSettings : ScriptableObject, IAdventOfCodeSettings
    {
        [SerializeField] private string m_Session;
        [SerializeField] private int m_Year;

        private static AdventOfCodeSettings _instance;

        public static AdventOfCodeSettings Instance
        {
            get
            {
                if (_instance != null) return _instance;

                var list = Resources.FindObjectsOfTypeAll<AdventOfCodeSettings>();
                Debug.Log("Looking For AdventOfCodeSettings in Resources, found " + list.Length);
                _instance = list.FirstOrDefault();
                if (_instance != null) return _instance;
                Debug.Log("Did not find AdventOfCodeSettings in Resources, Creating new");
                _instance = CreateInstance<AdventOfCodeSettings>();
                _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                AssetDatabase.Refresh();

                return _instance;
            }
        }

        public string Session => m_Session;
        public int Year => m_Year;

        private void OnEnable()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
            Debug.Log("OnEnable AdventOfCodeSettings");
        }

        private void OnDestroy()
        {
            Debug.Log("DESTROYING MY AdventOfCodeSettings");
        }
    }
}