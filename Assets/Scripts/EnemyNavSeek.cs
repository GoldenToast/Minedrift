using UnityEngine;
using System.Collections;

public class EnemyNavSeek : MonoBehaviour
{

	private Vector3 destination;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start ()
	{
		destination = randPosition ();
		agent = this.GetComponent<NavMeshAgent> ();
	}


	void OnDrawGizmos ()
	{
		if (destination != null) {
			
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (destination, .25f);
		}

	}

	private Vector3 randPosition ()
	{
		Vector3 dir = Random.insideUnitSphere * 20.0f;
		Vector3 newRandPos = this.transform.position + dir;
		NavMeshHit hit;
		NavMesh.SamplePosition (newRandPos, out hit, 20.0f, 1);
		return hit.position;
	}

	private Vector3 getNavPosition ()
	{
		if (Vector3.Distance (this.transform.position, destination) < 1) {
			destination = randPosition ();
		}
		/*
        • If a destination is set but the path is not yet processed the position returned will be valid navmesh position that's closest to the previously set position.
        • If the agent has no path or requested path - returns the agents position on the navmesh.
        • If the agent is not mapped to the navmesh (e.g. scene has no navmesh) - returns a position at infinity.
        */
		return destination;
	}


	// Update is called once per frame
	void Update ()
	{
		agent.SetDestination (getNavPosition ());
	}
}
