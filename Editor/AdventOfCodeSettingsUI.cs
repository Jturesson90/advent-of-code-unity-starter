using AdventOfCode.AOCClient;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class AdventOfCodeSettingsUI : EditorWindow
{
    [MenuItem("Window/JTuresson/Advent Of Code Settings")]
    public static void ShowExample()
    {
        AdventOfCodeSettingsUI wnd = GetWindow<AdventOfCodeSettingsUI>();
        wnd.titleContent = new GUIContent("AdventOfCodeSettingsUI");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;
        var settings = AdventOfCodeSettings.Instance;
        settings.Year = 2022;
        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Year: " + settings.Year + " Session Id = " + settings.Session);
        root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
            "Packages/com.jturesson.adventofcode.starter/Editor/AdventOfCodeSettingsUI.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(
            "Packages/com.jturesson.adventofcode.starter/Editor/AdventOfCodeSettingsUI.uss");
        VisualElement labelWithStyle = new Label("Hello World! With Style");
        labelWithStyle.styleSheets.Add(styleSheet);
        root.Add(labelWithStyle);
    }
}