using System.Collections.Generic;
using UnityEngine;
using VUD_Project.View;

namespace VUD_Project.Data
{
    public static class GameLogic
    {
        //Settings 
        public static Dictionary<int, BSlot> slotDictionary = new Dictionary<int, BSlot>(); 
        public static List<int> slotIDList = new List<int>();

        public static GameObject turret1;
        public static GameObject turret2;
        public static GameObject turret3;

       

        public static void CreateTurret(GameObject turret, Transform transform)
        {
            GameObject.Instantiate(turret,transform.position, transform.rotation);
        }
        public static void GetFolderPositionTurrets()
        {
            turret1 = Resources.Load<GameObject>("Turret/turret1");
            turret2 = Resources.Load<GameObject>("Turret/turret2");
            turret3 = Resources.Load<GameObject>("Turret/turret3");
        }



        public static void CreateEnemy(GameObject enemy, Transform transform)
        {
            GameObject.Instantiate(enemy, transform.position, transform.rotation);        
        }

        



    }
}

