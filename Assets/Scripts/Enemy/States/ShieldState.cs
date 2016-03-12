using UnityEngine;
using System.Collections;

public class ShieldState : DefendState {

    public ShieldState(BehaviorController controller)
        : base(controller) {

    }

    protected override Vector3 GetNavigationPosition() {
        throw new System.NotImplementedException();
    }
}
