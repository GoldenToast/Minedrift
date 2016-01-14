using UnityEngine;
using System.Collections;

public class PlayerShipMovement : MonoBehaviour {

    private const string HORIZONTAL1 = "Horizontal1";
    private const string VERTICAL1 = "Vertical1";

    private const string HORIZONTAL2 = "Horizontal2";
    private const string VERTICAL2 = "Vertical2";

    public int PlayerNumber;

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
    }

    void FixedUpdate() {
        rb.AddForce(transform.forward * moveDirection.y * forwardSpeed,ForceMode.Impulse);
		rb.AddTorque(transform.up * moveDirection.x * rotationSpeed,ForceMode.VelocityChange);
    }

}
