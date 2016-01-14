using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float bulletSpeed;
    public int damage;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * bulletSpeed *Time.deltaTime; 
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Laser enters " + other);
        if (other.tag.Equals("Enemy"))
        {
            Debug.Log("Damage " + other.gameObject.layer);
            other.gameObject.GetComponent<Hitable>().takeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.tag.Equals(this.tag))
        {
            Debug.Log("NoDamage to " + other);
        }
       
    }
}
