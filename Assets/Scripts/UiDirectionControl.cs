using UnityEngine;
using System.Collections;

public class UiDirectionControl : MonoBehaviour {

    public bool useRelativeRotation = true;

    private Quaternion relativeRotation;

    void Start () {
        relativeRotation = Quaternion.Euler(new Vector3(90,0,0));
	}
	
	void Update () {
        if (useRelativeRotation) {
            transform.rotation = relativeRotation;
        }
	}
}
