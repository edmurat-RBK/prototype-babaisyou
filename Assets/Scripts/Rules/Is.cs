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

        Vector2[] directionList = new Vector2[] { Vector2.up, Vector2.left };
        foreach(Vector2 direction in directionList)
        {
            RaycastHit2D[] firstNeighbourEntity = new RaycastHit2D[50];
            int firstNeighbourCount = gameObject.GetComponent<Collider2D>().Cast(direction, firstNeighbourEntity, 1);

            RaycastHit2D[] secondNeighbourEntity = new RaycastHit2D[50];
            int secondNeighbourCount = gameObject.GetComponent<Collider2D>().Cast(-direction, firstNeighbourEntity, 1);

            if (firstNeighbourCount > 0 && secondNeighbourCount > 0)
            {
                foreach(RaycastHit2D frch in firstNeighbourEntity)
                {
                    if(GameManager.Instance.dictNounWord.Keys.Contains(frch.collider.gameObject.GetComponent<GameEntity>().entityType))
                    {
                        foreach(RaycastHit2D srch in secondNeighbourEntity)
                        {
                            if(GameManager.Instance.dictAdjectiveWord.Keys.Contains(srch.collider.gameObject.GetComponent<GameEntity>().entityType))
                            {
                                // NOUN is ADJECTIVE
                                // TODO: Add Rule componement linked to adjective in objects linked to noun
                            }
                            else if (GameManager.Instance.dictNounWord.Keys.Contains(srch.collider.gameObject.GetComponent<GameEntity>().entityType))
                            {
                                // NOUN is NOUN
                                // TODO: Change object linked to first noun into object linked to second noun 
                            }
                        }
                    }
                }
            }
        }
    }
}
