using UnityEngine;
using System.Collections.Generic;

public class EnginePowerControl : MonoBehaviour {

	public List<ParticleSystem> psEngines;

	public float engineStartSpeed;

    private float power = 0;
	private float startSpeedMax;
	private ParticleSystem ps;

	public void adjustEnginePower(float magnitude)    {
		foreach (ParticleSystem ps in psEngines) {
			adjustEnginePower(ps,magnitude);
		}
	}


	void adjustEnginePower(ParticleSystem ps, float magnitude)    {
		power = Mathf.Abs(magnitude);
		power = Mathf.Clamp01(power);
		float speed = engineStartSpeed * power;
		ps.startSpeed = speed;
	}


}
