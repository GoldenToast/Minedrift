using UnityEngine;
using System.Collections;

public class UsageController : MonoBehaviour {


	private const string USE = "Use";

	private bool use;
	private GameObject usageObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!usageObject) {
			return;
		}
		use = Input.GetButton (USE);
		if (use) {
			if (usageObject.CompareTag (Tags.PLAYER_SHIP)) {
				enterShip ();
			}
		}
	}

	private void enterShip (){
		PlayerPersonController pController = GetComponentInParent<PlayerPersonController> ();
		pController.enterShip ();
		EntranceControl entrance = usageObject.GetComponent<EntranceControl> ();
		entrance.enterShip ();
	}
		
	void OnTriggerEnter(Collider other){
		if (other.CompareTag (this.tag)) {
			return;
		}
		Debug.Log ("UsageTriggerEnter " + other.name);
		usageObject = other.gameObject;
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag (this.tag)) {
			return;
		}
		Debug.Log ("UsageTriggerExit " + other.name);
		usageObject = null;
	}
}
