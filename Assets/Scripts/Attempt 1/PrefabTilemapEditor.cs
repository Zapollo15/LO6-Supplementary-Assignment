using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PrefabTilemap))]
public class PrefabTilemapEditor : Editor
{
    private PrefabTilemap tilemap;
    private int currentPrefabIndex = 0;

    private void OnEnable()
    {
        tilemap = (PrefabTilemap)target;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;
        Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
        Vector3 mousePosition = ray.origin;

        Vector2Int cellPosition = new Vector2Int(Mathf.FloorToInt(mousePosition.x), Mathf.FloorToInt(mousePosition.y));

        if (tilemap != null)
        {
            Handles.color = Color.red;
            Handles.DrawWireCube(new Vector3(cellPosition.x + 0.5f, cellPosition.y + 0.5f, 0), Vector3.one);
            tilemap.SetSelectedCell(cellPosition);

            if (e.type == EventType.KeyDown)
            {
                if (e.keyCode == KeyCode.UpArrow)
                {
                    currentPrefabIndex = (currentPrefabIndex + 1) % tilemap.prefabs.Length;
                    tilemap.ReplaceTile(currentPrefabIndex);
                    e.Use();
                }
                else if (e.keyCode == KeyCode.DownArrow)
                {
                    currentPrefabIndex = (currentPrefabIndex - 1 + tilemap.prefabs.Length) % tilemap.prefabs.Length;
                    tilemap.ReplaceTile(currentPrefabIndex);
                    e.Use();
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}
