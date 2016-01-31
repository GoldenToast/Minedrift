using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerShipMovement : MonoBehaviour {

    private const string HORIZONTAL1 = "Horizontal1";
    private const string VERTICAL1 = "Vertical1";

    private const string HORIZONTAL2 = "Horizontal2";
    private const string VERTICAL2 = "Vertical2";

    public int PlayerNumber;

    public float forwardSpeed;
	public float rotationSpeed;
	public float dashSpeed;

	private Vector2 moveDirection;
	private float sideDash;

	private float buttonCooler = 0.3f; // Half a second before reset
	private int buttonCount = 0;

	public List<ParticleSystem> psEngines;
    private Rigidbody rb;

    private float power = 0;
    private float startSpeedMax;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
		foreach (ParticleSystem ps in psEngines) {
			startSpeedMax = ps.startSpeed;
		}
		this.tag = this.tag + PlayerNumber;
    }
	
	// Update is called once per frame
	void Update () {
		if (PlayerNumber == 1) {
			handleInput(HORIZONTAL1, VERTICAL1);
		}
		if (PlayerNumber == 2) {
			handleInput(HORIZONTAL2, VERTICAL2);
		}

       
		foreach (ParticleSystem ps in psEngines) {
			adjustEnginePower(ps,moveDirection.y);
		}
    }

	private void handleInput(String horizontal, String vertical){

		float x = Input.GetAxis(horizontal);
		float y = Input.GetAxis(vertical);
		sideDash = 0;

		if (Input.GetButtonDown(horizontal)){
			if ( buttonCooler > 0 && buttonCount == 1/*Number of Taps you want Minus One*/){
				sideDash = Math.Sign(x);
				x = 0;
			}else{
				buttonCooler = 0.3f; 
				buttonCount += 1 ;
			}
		}
		if ( buttonCooler > 0 ){
			buttonCooler -= 1 * Time.deltaTime ;
		}else{
			buttonCount = 0 ;
		}

		moveDirection = new Vector2(x,y);
	}

    private void adjustEnginePower(ParticleSystem ps,  float y)    {
        power = Mathf.Abs(y);
        power = Mathf.Clamp01(power);
        float speed = startSpeedMax * power;
        ps.startSpeed = speed;

    }

    void FixedUpdate() {
        rb.AddForce(transform.forward * moveDirection.y * forwardSpeed,ForceMode.Impulse);
		rb.AddForce(transform.right * sideDash * dashSpeed,ForceMode.Impulse);
		rb.AddTorque(transform.up * moveDirection.x * rotationSpeed,ForceMode.VelocityChange);
    }

}
