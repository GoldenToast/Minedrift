using UnityEngine;
using System.Collections;

public class RammBehavior : EnemyAttackBehavior {

	private Vector3 oldDestination;

	public override Vector3 GetNavigationPosition () {
		if (player == null) {
			round = 0;
			return destination;
		}
			
		if (++round == 30) {
			base.Acceleration *= 2.0f;
			transform.RotateAround (Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		}

		if (round > 80) {
			if (round > 100) {
				round = 0;
			}

			// Change position
			if (Vector3.Distance (base.transform.position, player.position) < 10) {
				Vector3 delta = (player.position - this.transform.position);
				return destination = player.position + delta;
			}
		}
			
		if (oldDestination != null) {
			Vector3 delta = (player.position - oldDestination);
			oldDestination = player.position;

			// Target is moving
			if (Vector3.Distance (Vector3.zero, delta) > 3) {
				return destination = player.position + delta;
			}
		}
		return oldDestination = destination = player.position;
	}

	// Use this for initialization
	new void Start () {
		base.Start ();
		normalAcceleration = base.Acceleration;
		var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
		wanderBehavior.enabled = false;
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();
	}
}
