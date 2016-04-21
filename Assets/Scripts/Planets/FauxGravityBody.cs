using System;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour{

	public float rotationDamping;
	private FauxGravityAttractor attractor;
	private bool enable;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		GetComponent<Rigidbody> ().useGravity = false;
		enable = true;
	}
	

	// Update is called once per frame
	void FixedUpdate () {
		if (!enable || attractor == null) {
			return;
		}
		attractor.Attract (this);
	}

	public void enableAttractor(){
		enable = true;
	}

	public void disableAttractor(){
		enable = false;
	}

	public void setAttractor(FauxGravityAttractor attractor){
		Debug.Log ("Trigger New Attractor event: " + this.name + "-" + attractor);
		this.attractor = attractor;
	}

	public FauxGravityAttractor getAttractor(){
		return attractor;
	}
	
}
