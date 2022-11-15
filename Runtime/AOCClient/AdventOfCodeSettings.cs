using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace AdventOfCode.AOCClient
{
    public class AdventOfCodeSettings : ScriptableObject, IAdventOfCodeSettings
    {
        [SerializeField] private string m_Session;
        [SerializeField] private int m_Year;
        [SerializeField] private AdventOfCodeCache m_AdventOfCodeCache;
        public string Session => m_Session;
        public int Year => m_Year;
        public static AdventOfCodeSettings Instance { get; private set; }

        public static event Action ExistChanged;
        private void OnEnable()
        {
            Instance = this;
        }
#if UNITY_EDITOR
        public static void CreateAsset()
        {
            var path = EditorUtility.SaveFilePanelInProject("Advent of Code Settings",
                "AdventOfCodeSettings", "asset",
                "Please create the Settings for AdventOfCode");
            if (string.IsNullOrEmpty(path))
                return;

            var configObject = CreateInstance<AdventOfCodeSettings>();
            AssetDatabase.CreateAsset(configObject, path);

            // Add the config asset to the build
            var preloadedAssets = UnityEditor.PlayerSettings.GetPreloadedAssets().ToList();
            preloadedAssets.Add(configObject);
            PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
            Instance = configObject;
            var item = CreateInstance<AdventOfCodeCache>();
            item.name = ObjectNames.NicifyVariableName(nameof(AdventOfCodeCache));
            AssetDatabase.AddObjectToAsset(item, Instance);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(item));
            Instance.m_AdventOfCodeCache = item;
            ExistChanged?.Invoke();
        }
#endif
        public void ClearCache()
        {
            m_AdventOfCodeCache.DeleteAll();
        }

        public IAdventOfCodeCache GetCache()
        {
            if (m_AdventOfCodeCache)
                return m_AdventOfCodeCache;
            m_AdventOfCodeCache =
                AssetDatabase.LoadAssetAtPath<AdventOfCodeCache>(AssetDatabase.GetAssetPath(this));
            if (m_AdventOfCodeCache)
                return m_AdventOfCodeCache;
            throw new Exception(
                "Cant find Cache, please remove this AdventOfCode Settings and create new");
        }

        private void OnDestroy()
        {
            Debug.Log("AdventOfCodeSettings OnDestroy");
            Instance = null;
            ExistChanged?.Invoke();
        }
    }
}