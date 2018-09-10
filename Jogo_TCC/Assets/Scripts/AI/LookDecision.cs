using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "IA/Decisions/Look")]
public class LookDecision : Decision 
{

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    { 
        if (true) {   
            return true;
        } else 
        {
            return false;
        }
    }
}