using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Laser : MonoBehaviour {

	public float bulletSpeed;
    public int damage;


	private Rigidbody rb;
    
	// Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = transform.forward * bulletSpeed;
	}

	void OnTriggerEnter(Collider other) {
        if (other.tag.Equals(Tags.RADAR)) {
            return;
        }

        if (!other.tag.Equals(this.tag)) {
			if (other.gameObject.GetComponent<Hitable>() != null)
			{
				other.gameObject.GetComponent<Hitable>().takeDamage(damage);
			}
			Destroy(this.gameObject);
        }  
    }
}
