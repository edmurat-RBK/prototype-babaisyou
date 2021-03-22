using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public Direction lastDirection;
    public Stack<Direction> directionStack;

    private void Awake()
    {
        directionStack = new Stack<Direction>();
    }

    public void OnDirection(InputValue value)
    {
        Vector2 vectDir = value.Get<Vector2>();
        if(vectDir.x < 0)
        {
            lastDirection = Direction.LEFT;
        }
        else if (vectDir.x > 0)
        {
            lastDirection = Direction.RIGHT;
        }
        else if (vectDir.y < 0)
        {
            lastDirection = Direction.DOWN;
        }
        else if (vectDir.y > 0)
        {
            lastDirection = Direction.UP;
        }

        directionStack.Push(lastDirection);
    }
}
