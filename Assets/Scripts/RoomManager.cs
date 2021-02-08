using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProtoBaba
{
    public class RoomManager : MonoBehaviour
    {
        public List<Entity> entityList;

        private void Awake()
        {
            // Get all entities in the room
            GameObject[] entityArray = GameObject.FindGameObjectsWithTag("Entity");
            foreach(GameObject go in entityArray)
            {
                entityList.Add(go.GetComponent<Entity>());
            }
        }

        public void RunTick()
        {
            foreach(Entity e in entityList)
            {
                e.TickUpdate();
            }
        }
    }
}

