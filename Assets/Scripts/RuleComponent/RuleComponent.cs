using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class RuleComponent
{
    public abstract System.Type RuleType { get; }
}
