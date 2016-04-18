using UnityEngine;
using System.Collections;
using System;

public class PlayerPersonController : MonoBehaviour {

	private const string HORIZONTAL1 = "Horizontal1";

	public int playerNumber;

	private Rigidbody rb;
	private Animator animator;

	public float forwardSpeed;

	private Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerNumber == 1) {
			handleInput(HORIZONTAL1);
			handleAnimation ();
		}
	}


	void moveForward(float amount){
		rb.AddForce(transform.right * -1 * amount * forwardSpeed,ForceMode.Impulse);
	}
		
	void FixedUpdate() {
		Debug.Log ("Move Person: " + moveDirection);
		moveForward (moveDirection.x);
	}


	private void handleInput(String horizontal){
		float x = Input.GetAxis(horizontal);
		moveDirection = new Vector2(x,0);
	}


	private void handleAnimation(){
		if (moveDirection.x < 0) {
			animator.SetBool ("walk_east", true);
		} else {
			animator.SetBool ("walk_east", false);
		}
	}
}
