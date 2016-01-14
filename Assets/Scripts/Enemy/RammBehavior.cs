using UnityEngine;
using System.Collections;

public class RammBehavior : EnemyAttackBehavior {

	private int round = 0;

	public override Vector3 GetNavigationPosition () {
		if (player == null) {
			return destination;
		}

		if (++round > 20) {
			transform.RotateAround (Vector3.zero, Vector3.up, 20 * Time.deltaTime);
			round = 0;
		}
		return destination = player.position;
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
