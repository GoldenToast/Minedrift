using UnityEngine;
using System.Collections;

public class AttractionZone : MonoBehaviour {

	public float planet_radius;
	public float oversize = 1.25f;

	private FauxGravityAttractor attractor;

	void Start(){
		attractor = GetComponent<FauxGravityAttractor> ();

		SphereCollider attractionZone = this.gameObject.AddComponent<SphereCollider> ();
		attractionZone.isTrigger = true;
		attractionZone.radius = planet_radius * oversize;

	}
	
	void OnTriggerEnter(Collider other){
		Debug.Log ("TriggerEnter " + other.name);
		if (other != null && other.GetComponent<FauxGravityBody> () != null) {
			other.GetComponent<FauxGravityBody>().setAttractor(attractor);
		}
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("TriggerExit " + other.name);
		if (other != null && other.GetComponent<FauxGravityBody> () != null) {
			other.GetComponent<FauxGravityBody>().setAttractor(null);
		}
	}
}
