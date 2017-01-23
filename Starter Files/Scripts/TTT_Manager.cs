using UnityEngine;
using System.Collections;

public class TTT_Manager : MonoBehaviour {

	private BoardCreator BC;

    public bool cleanBoard;
    public static int playersCount = 2;
    public static int currentPlayer;

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
