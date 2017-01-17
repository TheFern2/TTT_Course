using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

	public Vector3 moveDestination;

	// Use this for initialization
	void Awake ()
	{
		moveDestination = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = moveDestination;
	}
}
