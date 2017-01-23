using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Vector2 gridPosition = Vector2.zero;

    public GameObject player1;
    public GameObject player2;

    public int playerIndex;

    void Start()
    {
        playerIndex = -1;
    }

    void OnMouseDown()
    {
        Debug.Log("My position is (" + gridPosition.x + "," + gridPosition.y + ")");

        if (this.playerIndex == -1)
        {
            // Place current player on the board
            if (TTT_Manager.currentPlayer == 0)
            {
                Instantiate(player1, this.transform.position, Quaternion.identity, TTT_Manager.playerClones);
                this.playerIndex = TTT_Manager.currentPlayer;
            }

            if (TTT_Manager.currentPlayer == 1)
            {
                Instantiate(player2, this.transform.position, Quaternion.identity, TTT_Manager.playerClones);
                this.playerIndex = TTT_Manager.currentPlayer;
            }
        }
        else
        {
            Debug.Log("Tile is occupied");
        }

        TTT_Manager.nextTurn();
    }
}
