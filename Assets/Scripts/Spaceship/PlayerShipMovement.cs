using UnityEngine;

using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnginePowerControl))]
public class PlayerShipMovement : MonoBehaviour {

	private const string HORIZONTAL = "Horizontal";
	private const string VERTICAL = "Vertical";
	private const string SPECIAL = "Special";
	private const string FIRE = "Fire2";

    public int playerNumber;

    public float forwardSpeed;
	public float sideSpeed;
	public float rotationSpeed;
	public float boostPower;
	public float boostCooldown;

	public float jumpDistance;
	public float jumpCooldown;

	private Vector2 moveDirection;
	private RaycastHit mouseHit;
	private Transform fixPoint;

	private Rigidbody rb;
	private EnginePowerControl engineControl;

 
	private float currentBoostCooldown;
	private float currentJumpCooldown;

    void Start () {
        rb = GetComponent<Rigidbody>();
		engineControl = GetComponent<EnginePowerControl>();
		this.tag = this.tag;
    }

	void Update () {
		handleInput(HORIZONTAL, VERTICAL);
		handleMouseLook ();
		rotate ();
		engineControl.adjustEnginePower (moveDirection.magnitude);
	}

	void FixedUpdate() {
		moveForward (moveDirection.y);
		moveSide (moveDirection.x);
    }

	void OnTriggerEnter(Collider other){
		if (other != null && other.GetComponent<AttractionZone> () != null) {
			fixPoint = other.transform;
		
		}
	}

	void OnTriggerExit(Collider other){
		if (other != null && other.GetComponent<AttractionZone> () != null) {
			fixPoint = null;
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawSphere (mouseHit.point, .3f);
	}

	private void handleInput(String horizontal, String vertical){
		float x = Input.GetAxis(horizontal);
		float y = Input.GetAxis(vertical);
		moveDirection = new Vector2(x,y);

		if (Input.GetButtonDown (SPECIAL) && currentBoostCooldown <= 0) {
			moveDirection *= boostPower;
			currentBoostCooldown = boostCooldown;
		} else {
			currentBoostCooldown -= 1 * Time.deltaTime ;
		}

		if (Input.GetButtonDown (FIRE) && currentJumpCooldown <= 0) {
			Jump();
			currentJumpCooldown = jumpCooldown;
		} else {
			currentJumpCooldown -= 1 * Time.deltaTime ;
		}
	}

	private void Jump(){
		transform.position += transform.forward.normalized * jumpDistance;
	}

	private void handleMouseLook(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		int MouseLookLayer = LayerMask.NameToLayer(Layers.MOUSE_HIT_PLANE);
		int MouseLookMask = 1 << MouseLookLayer; 
		Physics.Raycast (ray, out mouseHit, MouseLookMask);
	}

	private void rotate(){
		Vector3 lookPos = new Vector3 (mouseHit.point.x, 0, mouseHit.point.z) - transform.position;
		if (fixPoint) {
			lookPos = transform.position - fixPoint.position;
		}
		Quaternion newRot = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSpeed);
	}

	private void moveForward(float amount){
		rb.AddForce(Vector3.forward * amount * forwardSpeed,ForceMode.Impulse);
	}

	private void moveSide(float amount){
		rb.AddForce(Vector3.right * -1 * amount * sideSpeed,ForceMode.Impulse);
	}
}
