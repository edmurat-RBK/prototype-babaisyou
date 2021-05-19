using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity : MonoBehaviour
{
    public EntityType entityType;

    /* 
     * HasRule()
     * Get all Rule components of the GameEntity
     * Then, compare their Type with the given Type in parameter
     */
    public bool HasRule(Type ruleType) 
    {
        Rule[] rules = GetComponents<Rule>();
        foreach(Rule rule in rules) {
            if(rule.GetType() == ruleType) 
            {
                return true;
            }
        }
        return false;
    }
}
