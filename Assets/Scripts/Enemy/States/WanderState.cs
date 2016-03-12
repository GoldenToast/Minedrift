using UnityEngine;
using System.Collections;

public class WanderState : NavigationState {

    private Transform transform;

    public WanderState(BehaviorController controller) 
        : base(controller) {
        transform = controller.transform;
    }

    public override void OnTriggerEnter(Collider other) {
        if (other.tag.Contains(Tags.PLAYER)) {
            controller.SwitchBehavior(Behavior.Attack, other);
        } else if (other.tag.Equals(Tags.COLLECTABLE)) {
            controller.SwitchBehavior(Behavior.Defend, other);
        }
    }

    public override void OnTriggerExit(Collider other) {
        //Nuthin
    }

    protected override Vector3 GetNavigationPosition() {
        return IsApplicable() ? destination = randPosition(this.transform.position) : destination;
    }

    private bool IsApplicable() {
        return Vector3.Distance(transform.position, base.destination) < 3;
    }

    private Vector3 randPosition(Vector3 currentPosition) {
        Vector3 direction = Random.insideUnitSphere * 20.0f;
        NavMeshHit hit;
        NavMesh.SamplePosition(currentPosition + new Vector3(direction.x, 0.0f, direction.z), out hit, 20.0f, 1);
        return hit.position;
    }
}
