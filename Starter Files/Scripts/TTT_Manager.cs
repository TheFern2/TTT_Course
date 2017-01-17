using UnityEngine;
using System.Collections;

public class TTT_Manager : MonoBehaviour
{

	BoardCreator BC;

	void Awake ()
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		BC = GetComponent<BoardCreator> ();
		BC.generateMap (3, 3);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
		
}
