using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RuleMovement : Rule
{
    private bool moveChecked = false;

    public override void Step()
    {
        throw new System.NotImplementedException();
    }

    /*
     * Move()
     * Get all GameEntity in the direction of the mouvement
     * For each GameEntity, check if it has a constraints rule (Stop, Push...)
     * Then, if GameEntity is movable, move it. 
    */
    private bool movable;
    public bool Move(Direction direction) 
    {
        movable = true;
        if(!moveChecked) {
            moveChecked = true;

            RaycastHit2D[] rcHit = new RaycastHit2D[10];
            Collider2D collider = gameObject.GetComponent<Collider2D>();
            if(collider.Cast(ConvertDirection(direction), rcHit, 1) > 0)
            {
                foreach(RaycastHit2D hit in rcHit) {
                    GameEntity ge = hit.collider.gameObject.GetComponent<GameEntity>();
                    if(ge.HasRule(typeof(Stop))) 
                    {
                        movable = false;
                    }
                    else if(ge.HasRule(typeof(Push)))
                    {
                        Push pushRule = ge.GetComponent<Push>();
                        movable = pushRule.PushAction(direction);
                    }
                }
            }
        }

        if(movable) 
        {
            transform.position += ConvertDirection(direction);
        }

        return false;
    }

    private Vector3 ConvertDirection(Direction direction) 
    {
        Vector3 outValue;
        switch(direction)
        {
            case Direction.UP:
                outValue = Vector3.up;
                break;
            
            case Direction.DOWN:
                outValue = Vector3.down;
                break;

            case Direction.LEFT:
                outValue = Vector3.left;
                break;

            case Direction.RIGHT:
                outValue = Vector3.right;
                break;
            
            default:
                outValue = Vector3.zero;
                break;
        }
        return outValue;
    }
}
