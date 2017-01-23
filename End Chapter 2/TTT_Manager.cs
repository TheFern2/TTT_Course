using UnityEngine;
using System.Collections;

public class TTT_Manager : MonoBehaviour {

	private BoardCreator BC;

    public bool cleanBoard;
    public static int playersCount = 2;
    public static int currentPlayer;

    public static Transform playerClones;

    public static TTT_Manager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if(instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
	void Start ()
	{
	    BC = GetComponent<BoardCreator>();
        BC.generateMap();

	    startGame();

	    playerClones = new GameObject("Player Clones").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (cleanBoard)
	    {
	        startGame();
	    }
	}

    public void startGame()
    {
        currentPlayer = 0;

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            tile.GetComponent<Tile>().playerIndex = -1;
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            GameObject.Destroy(player);
        }
    }

    public static void nextTurn()
    {
        if (currentPlayer + 1 < playersCount)
        {
            currentPlayer++;
        }
        else
        {
            currentPlayer = 0;
        }
    }
}
