using UnityEngine;
using System.Collections;

/// <summary>
/// Controller for the rammer enemys.
/// </summary>
public class RammerController : BehaviorController {

    public void Start() {
        base.current = behaviors[Behavior.Wander];
    }

    public override void Awake() {
        behaviors.Add(Behavior.Wander, new WanderState(this));
        behaviors.Add(Behavior.Attack, new RammState(this));
    }
}
