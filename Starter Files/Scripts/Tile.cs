using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Vector2 gridPosition = Vector2.zero;

    public GameObject player1;
    public GameObject player2;

    public int playerIndex;

    void OnMouseDown()
    {
        Debug.Log("My position is (" + gridPosition.x + "," + gridPosition.y + ")");
    }
}
