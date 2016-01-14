using UnityEngine;
using System.Collections;

public abstract class NavigationBehavior : MonoBehaviour {

	protected NavMeshAgent agent;

	protected Vector3 destination;

	public void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	public void Update () {
		SetSpeedAndAcceleration ();
		agent.SetDestination (GetNavigationPosition ());
	}

	public abstract Vector3 GetNavigationPosition ();

	protected virtual void SetSpeedAndAcceleration () {
		agent.speed = 7;
		agent.acceleration = 8;
	}
}
