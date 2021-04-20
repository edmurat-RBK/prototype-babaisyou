using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsComponent : RuleComponent
{
    public override Type RuleType 
    { 
        get 
        {
            return typeof(Is); 
        }
    }
}
