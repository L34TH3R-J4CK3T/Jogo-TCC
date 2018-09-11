using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action {

    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        controller.Attack1();
        RaycastHit2D ground = Physics2D.Raycast(controller.groundEnd.position, Vector2.down, controller.distance);
        if (ground.collider == false)
        {
            controller.Attack2();
        }
    }
}
