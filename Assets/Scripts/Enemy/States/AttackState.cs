using UnityEngine;
using System.Collections;

public abstract class AttackState : NavigationState {

    protected Transform player = null;
    protected Transform transform;

    protected int round = 0;
    protected bool rage = false;

    private MonoBehaviour projectileControl;

    protected AttackState(BehaviorController controller)
        : base(controller) {
        transform = controller.transform;
        projectileControl = controller.GetComponent<EnemyProjectileControl>();
    }

    public override void OnTriggerEnter(Collider other) {
        if (other.tag.Contains(Tags.PLAYER)) {
            player = player ?? other.transform;
            projectileControl.enabled = true;
        }
    }

    public override void OnTriggerExit(Collider other) {
        if (other.tag.Contains(Tags.PLAYER)) {
            player = null;
            rage = false;
            projectileControl.enabled = false;
            controller.SwitchBehavior(Behavior.Wander);
        }
    }
}
