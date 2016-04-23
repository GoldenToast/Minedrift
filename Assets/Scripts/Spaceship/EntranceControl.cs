using UnityEngine;
using System.Collections;

public class EntranceControl : MonoBehaviour {

	public void enterShip(){
		Debug.Log ("SHIP ACTIVE");
		GetComponent<PlayerShipMovement> ().enabled = true;
	}

	public void exitShip(){
		Debug.Log ("SHIP DEACTIVE");
		GetComponent<PlayerShipMovement> ().enabled = false;
	}
}
