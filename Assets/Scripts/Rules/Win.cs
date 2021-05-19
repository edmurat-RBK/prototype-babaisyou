using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : Rule
{
    public override void Step()
    {
        if(gameObject.GetComponent<GameEntity>().HasRule(typeof(You))) {
            GameManager.Instance.Win();
        }
        else {
            RaycastHit2D[] hitArray = new RaycastHit2D[10];
            int hitCount = gameObject.GetComponent<Collider2D>().Cast(Vector3.up,hitArray,0.01f);

            for(int i = 0; i<hitCount ; i++) {
                if(hitArray[i].collider.gameObject.GetComponent<GameEntity>().HasRule(typeof(You))) {
                    GameManager.Instance.Win();
                }
            }
        }
    }
}
