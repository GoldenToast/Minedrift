using UnityEngine;
using System.Collections;

public class EngineControls : MonoBehaviour {

    private float power = 0;
	private float startSpeedMax;
	private ParticleSystem ps;

	void Start(){
		ps = GetComponent<ParticleSystem> ();
		startSpeedMax = ps.startSpeed;
	}

	// Update is called once per frame
	void Update () {
        power = Mathf.Abs(0);
        power = Mathf.Clamp01(power);
        float speed = startSpeedMax * power;
		ps.startSpeed = speed;
    }


}
