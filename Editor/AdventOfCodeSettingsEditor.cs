using AdventOfCode.AOCClient;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    [CustomEditor(typeof(AdventOfCodeSettings))]
    public class AdventOfCodeSettingsEditor : UnityEditor.Editor
    {
        [SerializeField] private VisualTreeAsset m_UXML;

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            m_UXML.CloneTree(root);
            InspectorElement.FillDefaultInspector(root, serializedObject, this);
            return root;
        }
    }
}