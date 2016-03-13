using UnityEngine;
using System.Collections;
using System;

public class ShooterController : BehaviorController {

    public void Start() {
        base.current = behaviors[Behavior.Wander];
    }

    public override void Awake() {
        behaviors.Add(Behavior.Wander, new WanderState(this));
        behaviors.Add(Behavior.Attack, new ShootState(this));
    }
}
