using UnityEngine;
using System.Collections;

public abstract class AttackState : NavigationState {

    protected Transform player = null;
    protected Transform transform;

    protected int round = 0;
    protected bool rage = false;

    private MonoBehaviour projectileControl;

	private int seen = 0;
	private int MAX_SEEN = 10;

    protected AttackState(BehaviorController controller)
        : base(controller) {
        transform = controller.transform;

        projectileControl = controller.GetComponent<EnemyProjectileControl>();
        projectileControl.enabled = false;
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

    //public override void Update() {
    //    if (--seen < 0) {
    //        Debug.Log("HALLO");
    //        player = null;
    //        rage = false;
    //        projectileControl.enabled = false;
    //        controller.SwitchBehavior(Behavior.Wander);
    //    } else {
    //        base.Update();
    //    }
    //}

    //public override void OnTriggerStay(Collider other) {
    //    if (other.tag.Contains(Tags.PLAYER)) {
    //        seen = MAX_SEEN;
    //    }
    //}
}
