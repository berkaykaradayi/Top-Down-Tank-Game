using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;
    //public bool targetInFOV = false;
    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }

        tank.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
       
        var direction = detector.Target.position - tank.aimturret.transform.position;
        if (Vector2.Angle(tank.aimturret.transform.right, direction) < fieldOfVisionForShooting / 2)
        {
            return true;
        }
        return false;
    }
}