using UnityEngine;
using System.Collections;

public class ShootState : AttackState {

    private const int PATIENCE = 40;
    private const int NEAR = 20;

    public ShootState(BehaviorController controller)
        : base(controller) {
    }

    private void RotateShipToPlayer() {
        var target = player.transform.position;
        var targetRotation = Quaternion.LookRotation(target - base.transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(base.transform.rotation, targetRotation, Time.deltaTime * 2.0f);
    }

    private void ResetFightMode() {
        round = 0;
        rage = false;
        //base.Speed = normalSpeed;

    }
    protected override Vector3 GetNavigationPosition() {
        if (player == null) {
            ResetFightMode();
            return destination;
        }

        RotateShipToPlayer();

        if (Vector3.Distance(base.transform.position, player.position) < NEAR) {
            if (++round == PATIENCE && !rage) {
                base.agent.speed *= 2.0f;
                base.agent.acceleration *= 2.0f;
                rage = true;
            }

            return destination = Vector3.Lerp(base.transform.position, base.transform.position * 1.1f, Time.deltaTime);
        } else {
            Vector3 delta = (player.position - this.transform.position);
            return destination = player.position + delta;          
        }      
    }
}
