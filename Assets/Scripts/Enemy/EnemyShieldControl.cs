using UnityEngine;
using System.Collections;

public class EnemyShieldControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EstimateCollision(Vector3 otherPosition, Vector3 otherForward) {
        Vector3 position = transform.position;
        Vector3 distance = position - otherPosition;

    }
}
