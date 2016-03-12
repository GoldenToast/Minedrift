using UnityEngine;
using System.Collections;

public class EnemyWanderBehavior : NavigationBehavior {

	private Vector3 randPosition(Vector3 pos){
		Vector2 dir = Random.insideUnitSphere * 20.0f;
		Vector3 newRandPos = pos + new Vector3(dir.x, 0, dir.y);
		NavMeshHit hit;
		NavMesh.SamplePosition(newRandPos, out hit, 20.0f, 1);
		return hit.position;
	}

	public bool IsApplicable () {
		return Vector3.Distance (this.transform.position, destination) < 3;
	}

	public override Vector3 GetNavigationPosition () {
		return IsApplicable () ? destination = randPosition (this.transform.position) : destination;
	}

//	void OnDrawGizmos () {
//		if (destination != null) {
//			Gizmos.color = Color.yellow;
//			Gizmos.DrawSphere (destination, .25f);
//		}
//	}

	// Use this for initialization
	new void Start () {
		base.Start ();
		destination = randPosition (this.transform.position);
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();
	}
}
