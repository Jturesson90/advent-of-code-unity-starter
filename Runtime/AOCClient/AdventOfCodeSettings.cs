using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace AdventOfCode.AOCClient
{
    [CreateAssetMenu]
    public class AdventOfCodeSettings : ScriptableObject, IAdventOfCodeSettings
    {
        [SerializeField] private string m_Session;
        [SerializeField] private int m_Year;
        public string Session => m_Session;
        public int Year => m_Year;
        public static AdventOfCodeSettings Instance { get; private set; }

        private void OnEnable()
        {
            Instance = this;
        }
#if UNITY_EDITOR
        [MenuItem("Window/JTuresson/Create Advent of Code Settings", true)]
        public static bool CanCreateAsset()
        {
            return Instance == null;
        }

        [MenuItem("Window/JTuresson/Create Advent of Code Settings")]
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
        }
#endif
    }
}