using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            InputManager[] managers = FindObjectsOfType(typeof(InputManager)) as InputManager[];
            if (managers.Length == 0)
            {
                Debug.LogWarning("InputManager not present on the scene. Creating a new one.");
                InputManager manager = new GameObject("Input Manager").AddComponent<InputManager>();
                _instance = manager;
                return _instance;
            }
            else
            {
                return managers[0];
            }
        }
        set
        {
            if (_instance == null)
                _instance = value;
            else
            {
                Debug.LogError("You can only use one InputManager. Destroying the new one attached to the GameObject " + value.gameObject.name);
                Destroy(value);
            }
        }
    }
    private static InputManager _instance = null;
    #endregion

    public Direction lastDirection;
    public Stack<Direction> directionStack;

    private void Awake()
    {
        directionStack = new Stack<Direction>();
    }

    public void OnDirection(InputValue value)
    {
        Debug.Log($"Player press a direction (Received input {value.Get<Vector2>()})");

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

        GameManager.Instance.PerformStep();
    }
}
