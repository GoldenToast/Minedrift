using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    public float bulletSpeed;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * bulletSpeed *Time.deltaTime; 
	}
}
