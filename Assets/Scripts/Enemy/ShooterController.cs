using UnityEngine;
using System.Collections;

/// <summary>
/// Controller for the shooter enemys.
/// </summary>
public class ShooterController : BehaviorController {

    public void Start() {
        base.current = behaviors[Behavior.Wander];
    }

    public override void Awake() {
        behaviors.Add(Behavior.Wander, new WanderState(this));
        behaviors.Add(Behavior.Attack, new ShootState(this));
    }

	void OnDrawGizmos(){
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(agent.destination, 1);
	}
}
