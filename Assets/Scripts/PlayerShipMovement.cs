using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public Vector2 moveDirection;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //TEST
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis(HORIZONTAL);
        float y = Input.GetAxis(VERTICAL);

        moveDirection = new Vector2(x,y);
    }

    void FixedUpdate() {
        rb.AddForce(transform.up * moveDirection.x);
    }
}
