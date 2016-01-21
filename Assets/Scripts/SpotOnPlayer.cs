using UnityEngine;
using System.Collections;

public class SpotOnPlayer : MonoBehaviour {

	public Transform playerSpot1;
	public Transform playerSpot2;
	private GameObject player1;
	private GameObject player2;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (player1 == null) {
			player1 = GameObject.FindGameObjectWithTag (Tags.PLAYER1);
		}
		if (player2 == null) {
			player2 = GameObject.FindGameObjectWithTag (Tags.PLAYER2);
		}
		playerSpot1.LookAt (player1.transform);
		playerSpot2.LookAt (player2.transform);
	}
}
