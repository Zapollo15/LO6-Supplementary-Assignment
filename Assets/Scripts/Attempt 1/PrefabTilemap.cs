using UnityEngine;

public class PrefabTilemap : MonoBehaviour
{
    public GameObject[] prefabs;
    private Vector2Int selectedCell;

    private void Start()
    {
        selectedCell = new Vector2Int(-1, -1); // Initialize to an invalid cell
    }

    public void SetSelectedCell(Vector2Int cell)
    {
        selectedCell = cell;
    }

    public Vector2Int GetSelectedCell()
    {
        return selectedCell;
    }

    public void ReplaceTile(int prefabIndex)
    {
        if (selectedCell.x < 0 || selectedCell.y < 0 || selectedCell.x >= transform.childCount || selectedCell.y >= transform.childCount)
        {
            return; // Out of bounds
        }

        Vector3 cellPosition = new Vector3(selectedCell.x, selectedCell.y, 0);
        Transform existingTile = transform.Find(cellPosition.ToString());

        if (existingTile != null)
        {
            DestroyImmediate(existingTile.gameObject);
        }

        GameObject newTile = Instantiate(prefabs[prefabIndex], cellPosition, Quaternion.identity);
        newTile.name = cellPosition.ToString();
        newTile.transform.parent = transform;
    }
}