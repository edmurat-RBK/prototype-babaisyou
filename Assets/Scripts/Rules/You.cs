using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class You : RuleMovement
{
    public override void Step()
    {
        Move(InputManager.Instance.lastDirection);
    }
}
