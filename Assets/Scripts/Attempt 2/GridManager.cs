using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public List<GameObject> prefabs; // List of available prefabs
    public int gridX = 5; // Changed to int to properly iterate
    public int gridY = 5; // Changed to int to properly iterate
    public float spacing = 2f;

    private GameObject[,] gridObjects; // To keep track of placed objects

    void Start()
    {
        gridObjects = new GameObject[gridX, gridY];
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector2 pos = new Vector2(x, y) * spacing;
                gridObjects[x, y] = Instantiate(prefabs[0], pos, Quaternion.identity); // Default to first prefab
            }
        }
    }

    public void ReplaceTile(int x, int y, int prefabIndex)
    {
        if (x < 0 || x >= gridX || y < 0 || y >= gridY) return;

        Vector2 pos = new Vector2(x, y) * spacing;
        gridObjects[x, y] = Instantiate(prefabs[prefabIndex], pos, Quaternion.identity);
    }
}