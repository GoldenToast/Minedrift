using UnityEngine;
using System.Collections;

public abstract class EnemyAttackBehavior : NavigationBehavior {
	
	protected Transform player = null;

	public float Speed;
	public float Acceleration;

	protected int round = 0;
	protected bool rage = false;

	protected float normalAcceleration;

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals (Tags.PLAYER1) || other.tag.Equals (Tags.PLAYER2)) {
			player = player ?? other.transform;
			var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = false;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag.Equals (Tags.PLAYER1) || other.tag.Equals (Tags.PLAYER2)) {
			player = null;
			var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = true;
			round = 0;
			normalAcceleration = Acceleration;
			rage = false;
		}
	}
		
	protected override void SetSpeedAndAcceleration () {
		base.agent.speed = Speed;
		base.agent.acceleration = Acceleration;
	}
}
