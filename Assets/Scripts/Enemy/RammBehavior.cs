using UnityEngine;
using System.Collections;

public class RammBehavior : EnemyAttackBehavior {

	public override Vector3 GetNavigationPosition () {
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
