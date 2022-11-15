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
        [SerializeField] private AdventOfCodePagination _pagination;

        [MenuItem("Window/JTuresson/Advent of Code Settings")]
        public static void ShowExample()
        {
            var wnd = GetWindow<AdventOfCodeSettingsWindow>();
            wnd.titleContent = new GUIContent("Advent of Code Settings Window");
        }

        private void OnProjectChange()
        {
            _settings = AdventOfCodeSettings.Instance;
        }

        private void OnEnable()
        {
            _settings = AdventOfCodeSettings.Instance;
            _pagination = AdventOfCodePagination.instance;
            AdventOfCodeSettings.ExistChanged += OnAdventOfCodeSettingsExistChanged;
        }

        private void OnFocus()
        {
            _settings = AdventOfCodeSettings.Instance;
            CreateGUI();
        }


        private void OnDisable()
        {
            AdventOfCodeSettings.ExistChanged -= OnAdventOfCodeSettingsExistChanged;
        }

        private void OnAdventOfCodeSettingsExistChanged()
        {
            _settings = AdventOfCodeSettings.Instance;
            CreateGUI();
        }

        public void CreateGUI()
        {
            rootVisualElement.Clear();
            m_VisualTreeAsset.CloneTree(rootVisualElement);
            var body = rootVisualElement.Q("body");
            var scrollView = new ScrollView() {viewDataKey = "AdventOfCodeSettingsScrollView"};
            if (_settings == null)
            {
                VisualElement button = new Button(AdventOfCodeSettings.CreateAsset)
                {
                    text = "Create settings"
                };

                scrollView.Add(button);
            }
            else
            {
                scrollView.Add(new InspectorElement(_settings));
                scrollView.Add(new InspectorElement(_pagination));
            }

            body.Add(scrollView);
        }
    }
}