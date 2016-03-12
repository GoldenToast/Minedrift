using UnityEngine;
using System.Collections;

public class ShootBehavior : EnemyAttackBehavior {

	private const int TOLERANCE = 40;

	private float normalSpeed;

	private void RotateShipToPlayer () {
		var target = player.transform.position;
		var targetRotation = Quaternion.LookRotation (target - base.transform.position, Vector3.up);
		transform.rotation = Quaternion.Slerp (base.transform.rotation, targetRotation, Time.deltaTime * 2.0f);
	}

	private void ResetFightMode () {
		round = 0;
		rage = false;
		base.Speed = normalSpeed;
	}

	public override Vector3 GetNavigationPosition () {
        
		if (player == null) {
			ResetFightMode ();
			IsPlayerInRange = false;
			return destination;
		}
		RotateShipToPlayer ();

		if (Vector3.Distance (base.transform.position, player.position) < 20) {
			IsPlayerInRange = true;
			if (++round == TOLERANCE) {
				base.Acceleration *= 2.0f;
				base.Speed *= 2.0f;
			}
			if (round % 80 < TOLERANCE) {
				rage = false;
			} else {
				rage = true;
			}

			if (!rage) {
				return destination = Vector3.Lerp (base.transform.position, base.transform.position * 1.1f, Time.deltaTime);
			} else {				
				Vector3 delta = (player.position - this.transform.position);
				return destination = player.position + delta;
			}
		}
		return destination = Vector3.Lerp (base.transform.position, player.position, Time.deltaTime);
	}

	// Use this for initialization
	new void Start () {
		normalSpeed = base.Speed;
		normalAcceleration = base.Acceleration;
		base.Start ();
		var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
		wanderBehavior.enabled = false;
	}

	// Update is called once per frame
	new void Update () {
		base.Update ();
	}
}
