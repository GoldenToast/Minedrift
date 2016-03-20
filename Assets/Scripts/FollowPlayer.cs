using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public int cameraSize;
    public GameObject target;

    private float yPos = 15;
    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Vector3 newPos = new Vector3(target.transform.position.x, yPos, target.transform.position.z);
            transform.position = newPos;
            cam.orthographicSize = cameraSize;
        }
    }
}
