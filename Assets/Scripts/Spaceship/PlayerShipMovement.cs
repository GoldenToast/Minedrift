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
    public Vector2 moveDirection;
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
        float x = 0;
        float y = 0;
        if (PlayerNumber == 1) {
            x = Input.GetAxis(HORIZONTAL1);
            y = Input.GetAxis(VERTICAL1);
        }
        if (PlayerNumber == 2)
        {
            x = Input.GetAxis(HORIZONTAL2);
            y = Input.GetAxis(VERTICAL2);
        }
        moveDirection = new Vector2(x,y);

		foreach (ParticleSystem ps in psEngines) {
			adjustEnginePower(ps,y);
		}
    }

    private void adjustEnginePower(ParticleSystem ps,  float y)    {
        power = Mathf.Abs(y);
        power = Mathf.Clamp01(power);
        float speed = startSpeedMax * power;
        ps.startSpeed = speed;

    }

    void FixedUpdate() {
        rb.AddForce(transform.forward * moveDirection.y * forwardSpeed,ForceMode.Impulse);
		rb.AddTorque(transform.up * moveDirection.x * rotationSpeed,ForceMode.VelocityChange);
    }

}
