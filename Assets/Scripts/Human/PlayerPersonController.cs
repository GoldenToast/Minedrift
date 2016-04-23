using UnityEngine;
using System.Collections;
using System;

public class PlayerPersonController : MonoBehaviour {

	private const string HORIZONTAL = "Horizontal";
	private const string JUMP = "Jump";

	public int playerNumber;

	private Rigidbody rb;
	private Animator animator;

	public float forwardSpeed;
	public float jumpHeight;

	private bool facingRight;
	private bool jump;
	private Vector2 moveDirection;
	private Vector3 attractorCenter;

	// Use this for initialization
	void Start () {
		facingRight = true;
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<FauxGravityBody> ().getAttractor()) {
			createPlayerPointOfRotation ();
		}
		if (playerNumber == 1) {
			handleInput();
			handleAnimation ();
		}
	}
		
	private void createPlayerPointOfRotation(){
		if (attractorCenter == Vector3.zero) {
			attractorCenter = GetComponent<FauxGravityBody> ().getAttractor().transform.position;
		}
	}

	void FixedUpdate() {
		move (moveDirection.x);
		performJump (jump);
	}

	public void enterShip(){
		Destroy(this.gameObject);
	}

	private void performJump(bool jump){
		if (jump) {
			rb.AddForce (transform.forward * jumpHeight , ForceMode.Impulse);
		}
	}

	private void move(float amount){
		transform.RotateAround (attractorCenter, transform.up, -1 * amount * forwardSpeed);
	}

	private void handleInput(){
		float x = Input.GetAxis(HORIZONTAL);
		moveDirection = new Vector2(x,0);
		jump = Input.GetButton (JUMP);
	}

	private void handleAnimation(){
		if (facingRight && moveDirection.x > 0 || !facingRight && moveDirection.x < 0) {
			facingRight = !facingRight;
			// Multiply the player's x local scale by -1
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		if (moveDirection.x > 0) {
			animator.SetInteger ("walkLR", 1);
		} else if (moveDirection.x < 0) {
			animator.SetInteger ("walkLR", -1);
		} else {
			animator.SetInteger ("walkLR", 0);
		}
	}


}
