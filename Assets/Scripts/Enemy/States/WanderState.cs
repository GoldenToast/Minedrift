using UnityEngine;
using System.Collections;

public class WanderState : NavigationState {

    private Transform transform;

    private const int ACCOMPLISHED = 3;

    public WanderState(BehaviorController controller) 
        : base(controller) {
        transform = controller.transform;
    }

    public override void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
		if (other.CompareTag(Tags.PLAYER_SHIP)) {
            controller.SwitchBehavior(Behavior.Attack, other);
        } else if (other.CompareTag(Tags.PLAYER_SHIP_LASER)) {
            controller.SwitchBehavior(Behavior.Defend, other);
        }
    }

    protected override Vector3 GetNavigationPosition() {
        return IsApplicable() ? destination = randPosition(this.transform.position) : destination;
    }

    private bool IsApplicable() {
        return Vector3.Distance(transform.position, base.destination) < ACCOMPLISHED;
    }

    private Vector3 randPosition(Vector3 currentPosition) {
        Vector3 direction = Random.insideUnitSphere * 20.0f;
        NavMeshHit hit;
        NavMesh.SamplePosition(currentPosition + new Vector3(direction.x, 0.0f, direction.z), out hit, 20.0f, 1);
        return hit.position;
    }

    public override void Start() {
        destination = randPosition(this.transform.position);
    }

    public override void OnTriggerExit(Collider other) {
        //Nuthin
    }
}
