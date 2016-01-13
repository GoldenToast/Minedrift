using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public int cameraSize;
    public GameObject target;

    private float zPos = -15;
    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, zPos);
            transform.position = newPos;
            cam.orthographicSize = cameraSize;
        }
    }
}
