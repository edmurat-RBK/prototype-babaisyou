using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rule : MonoBehaviour
{
    public abstract void Step();

    public void Remove() 
    { 
        Destroy(this);
    }

}
