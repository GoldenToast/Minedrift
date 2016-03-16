using UnityEngine;
using System.Collections;

public abstract class NavigationState : IEnemyState {

    protected readonly BehaviorController controller;

    protected NavMeshAgent agent;

    protected Vector3 destination;

    protected NavigationState(BehaviorController controller) {
        this.controller = controller;
        agent = controller.GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Gets the new position to which the enemy should be navigated.
    /// </summary>
    /// <returns>Vector3 with destination.</returns>
    protected abstract Vector3 GetNavigationPosition();

    /// <summary>
    /// Reset Speed and Acceleration.
    /// </summary>
    protected virtual void ResetSpeedAndAcceleration() {
        agent.speed = 7;
        agent.acceleration = 8;
    }

    public abstract void OnTriggerEnter(Collider other);

    public abstract void OnTriggerExit(Collider other);

	public abstract void OnTriggerStay(Collider other);

    public virtual void Update() {
        Vector3 destination = GetNavigationPosition();
        Debug.Log(destination);
        agent.SetDestination(destination);     
    }

    public virtual void Start() {
    }
}
