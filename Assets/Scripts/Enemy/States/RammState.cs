using UnityEngine;
using System.Collections;

public class RammState : AttackState {

    public RammState(BehaviorController controller)
        : base(controller) {
    }


    protected override Vector3 GetNavigationPosition() {
        if (player == null) {
            return base.destination;
        }

        return player.position;
    }
}
