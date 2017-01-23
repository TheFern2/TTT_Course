using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardCreator : MonoBehaviour
{

    public GameObject TilePrefab01;
    public GameObject TilePrefab02;

    public int width;
    public int height;

    private Transform generatedMap;

    List<List<Tile>> map = new List<List<Tile>>();

    public void generateMap()
    {
        generatedMap = new GameObject("Board").transform;

        for (int i = 0; i > -width; i--)
        {
            List<Tile> row = new List<Tile>();

            for (int j = 0; j < height; j++)
            {
                    Tile tile =
                    ((GameObject) Instantiate(TilePrefab01, new Vector3(j, i, 0), Quaternion.identity))
                        .GetComponent<Tile>();

                tile.gridPosition = new Vector2(j, i);
                tile.transform.SetParent(generatedMap);
                row.Add(tile);
            }

            map.Add(row);
        } 
    }
}
