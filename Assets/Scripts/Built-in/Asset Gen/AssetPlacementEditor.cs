using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AssetPlacement))]
public class AssetPlacementEditor: Editor {
    public override void OnInspectorGUI() {
        AssetPlacement assetPlacer = (AssetPlacement)target;

        // Draw the default view of the inspector
        DrawDefaultInspector();

        // Create a button to place assets in editor mode
        if(GUILayout.Button("Place Assets")) {
            assetPlacer.PlaceAssets();
        }
    }
}
