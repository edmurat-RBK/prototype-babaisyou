using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Is : Rule
{
    public override void Step()
    {
        /* 
         * For both direction (up/down and left/right)
         * Check if there is two neighbour tiles
         * Then, check if the first one is a noun
         * Then, check if the second one is a noun or an adjective
         */

        //Debug.Log($"{gameObject.name} is performing a step");

        Vector2[] directionList = new Vector2[] { Vector2.up, Vector2.left };
        foreach(Vector2 direction in directionList)
        {
            RaycastHit2D[] firstNeighbourEntity = new RaycastHit2D[10];
            int firstNeighbourCount = gameObject.GetComponent<Collider2D>().Cast(direction, firstNeighbourEntity, 1f);

            RaycastHit2D[] secondNeighbourEntity = new RaycastHit2D[10];
            int secondNeighbourCount = gameObject.GetComponent<Collider2D>().Cast(-direction, secondNeighbourEntity, 1f);

            //Debug.Log($"#first hits ({firstNeighbourCount}) and #second hits ({secondNeighbourCount})");

            if (firstNeighbourCount > 0 && secondNeighbourCount > 0)
            {
                foreach(RaycastHit2D frch in firstNeighbourEntity)
                {
                    if(frch.collider != null) 
                    {
                        //Debug.Log($"Hit #1 : {frch.collider.gameObject.name}");
                        if(GameManager.Instance.dictNounWord.Keys.Contains(frch.collider.gameObject.GetComponent<GameEntity>().entityType))
                        {
                            foreach(RaycastHit2D srch in secondNeighbourEntity)
                            {
                                if(srch.collider != null) 
                                {
                                    //Debug.Log($"Hit #2 : {srch.collider.gameObject.name}");
                                    if(GameManager.Instance.dictAdjectiveWord.Keys.Contains(srch.collider.gameObject.GetComponent<GameEntity>().entityType))
                                    {
                                        // NOUN is ADJECTIVE
                                        // Add Rule componement linked to adjective in objects linked to noun
                                        EntityType entityType = GameManager.Instance.dictNounWord[frch.collider.gameObject.GetComponent<GameEntity>().entityType];
                                        Type ruleType = GameManager.Instance.dictAdjectiveWord[srch.collider.gameObject.GetComponent<GameEntity>().entityType];
                                        //Debug.Log($"Add Component {ruleType} to {entityType} ({entityType} is {ruleType})");
                                        foreach(GameObject go in GameManager.Instance.gameEntityList) 
                                        {
                                            if(go.GetComponent<GameEntity>().entityType == entityType) 
                                            {
                                                go.AddComponent(ruleType);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
