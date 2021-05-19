using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : RuleMovement
{
    public override void Step()
    {
        // Nothing happens at each step
    }

    public bool PushAction(Direction direction) 
    { 
        return Move(direction);
    }
}
