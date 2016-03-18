using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldState : DefendState {

    public ShieldState(BehaviorController controller)
        : base(controller) {

    }

    public override void OnTriggerEnter(Collider other) {
        
    }

    public override void OnTriggerExit(Collider other) {
        //Nuthin
    }

    protected override Vector3 GetNavigationPosition() {
        throw new System.NotImplementedException();
    }
}
