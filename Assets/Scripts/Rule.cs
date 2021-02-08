using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule : MonoBehaviour
{
    public void RemoveRule()
    {
        Destroy(gameObject);
    }

    public abstract void PerformStep();
}
