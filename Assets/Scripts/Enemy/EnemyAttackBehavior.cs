using UnityEngine;
using System.Collections;

public abstract class EnemyAttackBehavior : NavigationBehavior {
	
	protected Transform player = null;

	public float Speed;
	public float Acceleration;

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals ("Player")) {
			player = player ?? other.transform;
			var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = false;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag.Equals ("Player")) {
			player = null;
			var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = true;
		}
	}
		
	protected override void SetSpeedAndAcceleration () {
		base.agent.speed = Speed;
		base.agent.acceleration = Acceleration;
	}
}
