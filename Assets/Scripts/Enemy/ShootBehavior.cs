using UnityEngine;
using System.Collections;

public class ShootBehavior : EnemyAttackBehavior {

	public override Vector3 GetNavigationPosition () {
		if (player == null) {
			return destination;
		}

		var target = player.transform.position;
		var targetRotation = Quaternion.LookRotation (target - base.transform.position, Vector3.up);
		transform.rotation = Quaternion.Slerp (base.transform.rotation, targetRotation, Time.deltaTime * 2.0f);

		if (Vector3.Distance (base.transform.position, player.position) < 5) {
			return destination;
		}
		return player == null ? destination : destination = player.position;
	}

	// Use this for initialization
	new void Start () {
		base.Start ();
	}

	// Update is called once per frame
	new void Update () {
		base.Update ();
	}
}
