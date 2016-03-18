using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Behavior {
    Wander, Attack, Defend
};

public abstract class BehaviorController : MonoBehaviour {

    protected IEnemyState current { get; set; }

    protected readonly IDictionary<Behavior, IEnemyState> behaviors 
        = new Dictionary<Behavior, IEnemyState>();

    void Update() {
		Debug.Log (this.name + " state " + current);
        current.Update();
    }

    void OnTriggerEnter(Collider other) {
        current.OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other) {
        current.OnTriggerExit(other);
    }

    //void OnTriggerStay(Collider other) {
    //    current.OnTriggerStay (other);
    //}

    public abstract void Awake();

    public virtual void SwitchBehavior(Behavior behavior) {
        if (behaviors.ContainsKey(behavior)) {
            current = behaviors[behavior];
        }
    }

    public virtual void SwitchBehavior(Behavior behavior, Collider other) {
        if (behaviors.ContainsKey(behavior)) {
            current = behaviors[behavior];
            current.OnTriggerEnter(other);
        }
    }
}
