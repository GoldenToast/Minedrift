using UnityEngine;
using System.Collections;

public class EnemyWanderBehavior : NavigationBehavior {

	private Vector3 RandPosition () {
		Vector3 dir = Random.insideUnitSphere * 20.0f;
		Vector3 newRandPos = this.transform.position + dir;
		NavMeshHit hit;
		NavMesh.SamplePosition (newRandPos, out hit, 20.0f, 1);
		return hit.position;
	}

	public bool IsApplicable () {
		return Vector3.Distance (this.transform.position, destination) < 1;
	}

	public override Vector3 GetNavigationPosition () {
		return IsApplicable () ? destination = RandPosition () : destination;
	}

	void OnDrawGizmos () {
		if (destination != null) {

			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (destination, .25f);
		}

	}

	// Use this for initialization
	new void Start () {
		destination = RandPosition ();
		base.Start ();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();
	}
}
