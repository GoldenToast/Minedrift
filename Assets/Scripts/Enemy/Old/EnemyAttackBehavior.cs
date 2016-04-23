using UnityEngine;
using System.Collections;

public abstract class EnemyAttackBehavior : NavigationBehavior {
	
	protected Transform player = null;

	public float Speed;
	public float Acceleration;

	protected int round = 0;
	protected bool rage = false;

	protected float normalAcceleration;

    public bool IsPlayerInRange { get; set; }

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals (Tags.PLAYER_SHIP)) {
			player = player ?? other.transform;
			var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = false;

            var attackBehavoir = GetComponent<EnemyAttackBehavior>();
            attackBehavoir.enabled = true;
        } else if (other.tag.Equals(Tags.COLLECTABLE)) {
            Debug.Log("LI LA LASER");
        }
	}

	void OnTriggerExit (Collider other) {
		if (other.tag.Equals (Tags.PLAYER_SHIP)) {
			player = null;
			var wanderBehavior = GetComponent<EnemyWanderBehavior> ();
			wanderBehavior.enabled = true;

            var attackBehavoir = GetComponent<EnemyAttackBehavior>();
            attackBehavoir.enabled = false;

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
