using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardCreator : MonoBehaviour
{
	public static BoardCreator instance;
	public GameObject TilePrefab01;
	public GameObject TilePrefab02;
	public bool isCheckered = false;

	private int width;
	private int height;

	private Transform generatedMap;
	public PlayerManager player1;
	public PlayerManager player2;

	List <List<Tile>> map = new List<List<Tile>> ();

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{

	}


	// Update is called once per frame
	void Update ()
	{

	}

	public void movePlayer (Tile destTile)
	{
		//move player to destination tile
		player1.moveDestination = destTile.transform.position + Vector3.back;

	}

	public void generateMap (int width, int height)
	{
		// This sets placeholder in the hierarchy
		generatedMap = new GameObject ("Board").transform;

		map = new List<List<Tile>> ();

		for (int i = 0; i < width; i++) {

			List <Tile> row = new List<Tile> ();

			for (int j = 0; j < height; j++) {

				// This is added for board games with checkered patterns such as checkers, chess, etc.
				if (isCheckered) {
					if ((i + j) % 2 == 0) {
						Tile tile = ((GameObject)Instantiate (TilePrefab01, new Vector3 (i - Mathf.Floor (width / 2),
							            -j + Mathf.Floor (height / 2), 0),
							            Quaternion.identity)).GetComponent<Tile> ();

						tile.gridPosition = new Vector2 (j, i);
						tile.transform.SetParent (generatedMap);
						row.Add (tile);
						Debug.Log ("TilePrebaf01 condition " + i + " " + j);
					}
					if ((i + j) % 2 == 1) {
						Tile tile2 = ((GameObject)Instantiate (TilePrefab02, new Vector3 (i - Mathf.Floor (width / 2),
							             -j + Mathf.Floor (height / 2), 0),
							             Quaternion.identity)).GetComponent<Tile> ();
					
					
						tile2.gridPosition = new Vector2 (j, i);
						tile2.transform.SetParent (generatedMap);
						row.Add (tile2);
						Debug.Log ("TilePrebaf02 condition " + i + " " + j);
					}
				}

				// If is not checkered all tiles will be the same
				if (!isCheckered) {
					// Create an instance of Tile as a GO in our 3d world
					// Note: We use Quaternion.identity since we have no use for rotation in this object
					// In our 3d world the tiles will be placed as follows X, Y, all Z's are ZERO:
					// We are creating tiles from top row, left to right... and so on.
					/*            │              │                 
					┌─────────┐      ┌─────────┐    ┌─────────┐    
					│         │   │  │         │ │  │         │    
					│ -1, 1   │      │  0, 1   │    │  1, 1   │    
					│         │   │  │         │ │  │         │    
					│         │      │         │    │         │    
					└─────────┘   │  └─────────┘ │  └─────────┘    

				 ─ ─ ─ ─ ─ ─ ─ ─ ─│─ ─ ─ ─ ─ ─ ─ ┼ ─ ─ ─ ─ ─ ─ ─ ─ 
					┌─────────┐      ┌─────────┐    ┌─────────┐    
					│         │   │  │         │ │  │         │    
					│ -1, 0   │      │  0, 0   │    │  1, 0   │    
					│         │   │  │         │ │  │         │    
					│         │      │         │    │         │    
					└─────────┘   │  └─────────┘ │  └─────────┘    
				─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ 
					┌─────────┐   │  ┌─────────┐ │  ┌─────────┐    
					│         │      │         │    │         │    
					│ -1,-1   │   │  │  0,-1   │ │  │  1,-1   │    
					│         │      │         │    │         │    
					│         │   │  │         │ │  │         │    
					└─────────┘      └─────────┘    └─────────┘    
					              │              │                 

					              │              │              */   
					
					// Mathf.Floor takes a float and Returns the largest integer smaller to or equal to f.
					// I.e 1.5f = 1, -10.2f = -11
					Tile tile = ((GameObject)Instantiate (TilePrefab01, new Vector3 (i - Mathf.Floor (width / 2),
						            -j + Mathf.Floor (height / 2), 0),
						            Quaternion.identity)).GetComponent<Tile> ();
					

					// Here we add tile to a Vector2 map
					// We want our board positions X, Y as follows:
					//                
					/*            │              │                 
					┌─────────┐      ┌─────────┐    ┌─────────┐    
					│         │   │  │         │ │  │         │    
					│  0, 0   │      │  0, 1   │    │  0, 2   │    
					│         │   │  │         │ │  │         │    
					│         │      │         │    │         │    
					└─────────┘   │  └─────────┘ │  └─────────┘    

				 ─ ─ ─ ─ ─ ─ ─ ─ ─│─ ─ ─ ─ ─ ─ ─ ┼ ─ ─ ─ ─ ─ ─ ─ ─ 
					┌─────────┐      ┌─────────┐    ┌─────────┐    
					│         │   │  │         │ │  │         │    
					│  1, 0   │      │  1, 1   │    │  1, 2   │    
					│         │   │  │         │ │  │         │    
					│         │      │         │    │         │    
					└─────────┘   │  └─────────┘ │  └─────────┘    
				─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ 
					┌─────────┐   │  ┌─────────┐ │  ┌─────────┐    
					│         │      │         │    │         │    
					│  2, 0   │   │  │  2, 1   │ │  │  2, 2   │    
					│         │      │         │    │         │    
					│         │   │  │         │ │  │         │    
					└─────────┘      └─────────┘    └─────────┘    
					              │              │                 

					              │              │              */   

					tile.gridPosition = new Vector2 (j, i);
					tile.transform.SetParent (generatedMap);
					row.Add (tile);
				}
			}

			map.Add (row);
		}
	}
}
