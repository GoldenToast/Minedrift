using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerShipMovement : NetworkBehaviour {

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

	public float forwardSpeed;
	public float rotationSpeed;
    public Vector2 moveDirection;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        float x = Input.GetAxis(HORIZONTAL);
        float y = Input.GetAxis(VERTICAL);

        moveDirection = new Vector2(x,y);
    }

    void FixedUpdate() {
        if (!isLocalPlayer)
        {
            return;
        }
        rb.AddForce(transform.forward * moveDirection.y * forwardSpeed,ForceMode.Impulse);
		rb.AddTorque(transform.up * moveDirection.x * rotationSpeed,ForceMode.Impulse);
    }

}
