using UnityEngine;
using System.Collections;

public abstract class DefendState : NavigationState {

    private const float TIMER_MAX = 5.0f;
    private const float TIMER_EXCEEDED = 0.0f;

    private float timerLeft;

    public DefendState(BehaviorController controller)
        : base(controller) {
    }

    public override void Update() {
        timerLeft -= Time.deltaTime;
        base.Update();

        if (timerLeft < TIMER_EXCEEDED) {
            controller.SwitchBehavior(Behavior.Wander);
        }
    }

    public override void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Tags.PLAYER_SHIP_LASER)) {
            timerLeft = TIMER_MAX;
		} else if (other.tag.Equals(Tags.PLAYER_SHIP)) {
            controller.SwitchBehavior(Behavior.Attack, other);
        }
    }
}
