using UnityEngine;
using System.Collections;

public class EnemyAttackBehavior : NavigationBehavior {
	
	private Transform player = null;

	public float Speed;
	public float Acceleration;

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals ("Player")) {
			player = player ?? other.transform;
			MonoBehaviour wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = false;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag.Equals ("Player")) {
			player = null;
			MonoBehaviour wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = true;
		}
	}

	public override Vector3 GetNavigationPosition () {
		return player == null ? destination : destination = player.position;
	}

	new void Start () {
		base.Start ();
	}

	protected override void SetSpeedAndAcceleration () {
		base.agent.speed = Speed;
		base.agent.acceleration = Acceleration;
	}

	new void Update () {
		base.Update ();
	}
}
