using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShipMovement : MonoBehaviour {

    private const string HORIZONTAL1 = "Horizontal1";
    private const string VERTICAL1 = "Vertical1";

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

//	private float sideDash;
//	private float buttonCooler = 0.3f; // Half a second before reset
//	private int buttonCount = 0;

	public List<ParticleSystem> psEngines;
    private Rigidbody rb;

    private float power = 0;
    private float startSpeedMax;
	private float currentBoostCooldown;
	private float currentJumpCooldown;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
		foreach (ParticleSystem ps in psEngines) {
			startSpeedMax = ps.startSpeed;
		}
		this.tag = this.tag/* + playerNumber*/;
    }
	
	// Update is called once per frame
	void Update () {
		if (playerNumber == 1) {
			handleInput(HORIZONTAL1, VERTICAL1);
			handleMouseLook ();
			rotate ();
		}
		       
		foreach (ParticleSystem ps in psEngines) {
			adjustEnginePower(ps,moveDirection.magnitude);
		}
    }

	private void handleInput(String horizontal, String vertical){
		float x = Input.GetAxis(horizontal);
		float y = Input.GetAxis(vertical);
		moveDirection = new Vector2(x,y);

		if (Input.GetButtonDown ("Special") && currentBoostCooldown <= 0) {
			moveDirection *= boostPower;
			currentBoostCooldown = boostCooldown;
		} else {
			currentBoostCooldown -= 1 * Time.deltaTime ;
		}

		if (Input.GetButtonDown ("Fire2") && currentJumpCooldown <= 0) {
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

    private void adjustEnginePower(ParticleSystem ps, float y)    {
        power = Mathf.Abs(y);
        power = Mathf.Clamp01(power);
        float speed = startSpeedMax * power;
        ps.startSpeed = speed;
    }
		
	void rotate(){
		Vector3 rotation = Vector3.Lerp (transform.forward, transform.position + mouseHit.point, Time.deltaTime * rotationSpeed);
		transform.LookAt (new Vector3(mouseHit.point.x, 0 , mouseHit.point.z ), transform.up);
	}

	void moveForward(float amount){
		rb.AddForce(Vector3.forward * amount * forwardSpeed,ForceMode.Impulse);
	}

	void moveSide(float amount){
		rb.AddForce(Vector3.right * -1 * amount * sideSpeed,ForceMode.Impulse);
	}

    void FixedUpdate() {
		Debug.Log (moveDirection);
		moveForward (moveDirection.y);
		moveSide (moveDirection.x);
    }

	void OnDrawGizmos(){
		Gizmos.DrawSphere (mouseHit.point, .3f);
	}
}
