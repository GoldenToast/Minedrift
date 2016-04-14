using UnityEngine;
using System.Collections;

public class FauxGravityAttractor : MonoBehaviour {

	private float gravity = -9.81f;

	void Start(){
	//	EventManager.StartListening ();
	}

	public void Attract(FauxGravityBody body){
		Vector3 gravityUp = (body.transform.position - transform.position).normalized;
		Vector3 bodyUp = body.transform.up;

		body.GetComponent<Rigidbody> ().AddForce (gravityUp *gravity);
		Quaternion targetRotation = Quaternion.FromToRotation (bodyUp, gravityUp) * body.transform.rotation;
		body.transform.rotation = Quaternion.Slerp (body.transform.rotation, targetRotation, body.rotationDamping*Time.deltaTime);
	}

	void OnEnable(){
		//EventManager.StartListening (Events.PLANET_DATA_CHANGE, handlePlanetDataChangeEvent);
	}

	void OnDisabele()	{
		//EventManager.StopListening (Events.PLANET_DATA_CHANGE, handlePlanetDataChangeEvent);
	}
}
