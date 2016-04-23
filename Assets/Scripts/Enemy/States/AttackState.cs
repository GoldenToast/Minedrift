using UnityEngine;
using System.Collections;

public abstract class AttackState : NavigationState {

    protected Transform player = null;
    protected Transform transform;

    protected int round = 0;
    protected bool rage = false;

    private MonoBehaviour projectileControl;

    protected AttackState(BehaviorController controller): base(controller) {
        transform = controller.transform;

        projectileControl = controller.GetComponent<EnemyProjectileControl>();
        projectileControl.enabled = false;
    }

    public override void OnTriggerEnter(Collider other) {
		if (other.CompareTag(Tags.PLAYER_SHIP)) {
            player = player ?? other.transform;
            projectileControl.enabled = true;
        }
    }

    public override void OnTriggerExit(Collider other) {
		if (other.CompareTag(Tags.PLAYER_SHIP)) {
            player = null;
            rage = false;
            projectileControl.enabled = false;
            controller.SwitchBehavior(Behavior.Wander);
        }
    }


}
