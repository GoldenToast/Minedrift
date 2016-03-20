using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldState : DefendState {

    private EnemyShieldControl shieldControl;

    public ShieldState(BehaviorController controller)
        : base(controller) {

        //shieldControl = controller.GetComponent<EnemyShieldControl>();
        //shieldControl.enabled = false;
    }

    public override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);

        if (other.CompareTag(Tags.LASER)) {
            //shieldControl.enabled = true;
        }
    }

    public override void OnTriggerExit(Collider other) {
    }

    protected override Vector3 GetNavigationPosition() {
        return base.destination = base.agent.transform.position;
    }
}
