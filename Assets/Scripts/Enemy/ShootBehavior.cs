using UnityEngine;
using System.Collections;

public class ShootBehavior : EnemyAttackBehavior {

	private int round = 0;
	private bool fightMode = false;

	private float normalSpeed, normalAcceleration;

	public bool IsPlayerInRange { get; set; }

	private void RotateShipToPlayer () {
		var target = player.transform.position;
		var targetRotation = Quaternion.LookRotation (target - base.transform.position, Vector3.up);
		transform.rotation = Quaternion.Slerp (base.transform.rotation, targetRotation, Time.deltaTime * 2.0f);
	}

	private void ResetFightMode () {
		round = 0;
		fightMode = false;
		base.Speed = normalSpeed;
		base.Acceleration = normalAcceleration;
	}

	public override Vector3 GetNavigationPosition () {
		if (player == null) {
			ResetFightMode ();
			IsPlayerInRange = false;
			return destination;
		}
		RotateShipToPlayer ();

		if (Vector3.Distance (base.transform.position, player.position) < 10) {
			IsPlayerInRange = true;
			if (++round == 40) {
				base.Acceleration = base.Acceleration * 2;
				base.Speed = Speed * 2.0f;
			}
			if (round % 80 < 40) {
				fightMode = false;
			} else {
				fightMode = true;
			}

			if (!fightMode) {
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
	}

	// Update is called once per frame
	new void Update () {
		base.Update ();
	}
}
