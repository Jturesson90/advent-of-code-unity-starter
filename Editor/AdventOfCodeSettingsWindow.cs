using System;
using AdventOfCode.AOCClient;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class AdventOfCodeSettingsWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;
        [SerializeField] private AdventOfCodeSettings _settings;

        [MenuItem("Window/JTuresson/Advent of Code Settings")]
        public static void ShowExample()
        {
            var wnd = GetWindow<AdventOfCodeSettingsWindow>();
            wnd.titleContent = new GUIContent("Advent of Code Settings Window");
        }

        private void OnEnable()
        {
            _settings = AdventOfCodeSettings.Instance;
        }

        public void CreateGUI()
        {
            if (_settings == null) return;
            var scrollView = new ScrollView() {viewDataKey = "AdventOfCodeSettingsScrollView"};
            scrollView.Add(new InspectorElement(_settings));
            rootVisualElement.Add(scrollView);
        }
    }
}