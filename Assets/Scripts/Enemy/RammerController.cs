using UnityEngine;
using System.Collections;

public class RammerController : BehaviorController {

    public new void Start() {
        base.current = behaviors[Behavior.Wander];
    }

    public override void Awake() {
        behaviors.Add(Behavior.Wander, new WanderState(this));
    }
}
