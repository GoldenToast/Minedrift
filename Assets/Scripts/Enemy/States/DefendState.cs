using UnityEngine;
using System.Collections;

public abstract class DefendState : NavigationState {

    private const float timerMaximum = 5.0f;
    private float timerLeft;

    public DefendState(BehaviorController controller)
        : base(controller) {
    }

    public override void Update() {
        timerLeft -= Time.deltaTime;
        base.Update();

        if (timerLeft < 0.0f) {
            controller.SwitchBehavior(Behavior.Wander);
        }
    }

    public override void OnTriggerEnter(Collider other) {
        if (other.tag.Equals(Tags.LASER)) {
            timerLeft = timerMaximum;
        } else if (other.tag.Equals(Tags.PLAYER)) {
            controller.SwitchBehavior(Behavior.Attack, other);
        }
    }

    public override void OnTriggerExit(Collider other) {
        // Nuthin
    }

	public override void OnTriggerStay (Collider other) {
	}
}
