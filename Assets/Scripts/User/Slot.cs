using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;

namespace VUD_Project.User
{
    public class Slot : MonoBehaviour
    {

        //Settings       
        protected int SlotID;
        protected static List <Slot> slots = new List <Slot> ();
       

        //Values
        protected bool isSlotEmpty;



        public int GenerateSlotID()  
        {
            int SlotID;
            do
            {
                SlotID = Random.Range(0, 1000);
                if (GameLogic.slotIDList.Contains(SlotID))
                {
                    continue;
                }
                GameLogic.slotIDList.Add(SlotID);
                return SlotID;
            } while (true);

        }

        public int GetSlotID()
        {
            return SlotID;
        }

        public Transform GetSlotTrasnform(int SlotID)   
        {
            return GameLogic.slotDictionary[SlotID].transform;
        }

        public bool GetSlotEmptyValue()  
        {
            return isSlotEmpty;
        }

        public void SetSlotEmptyValue(bool value) 
        {
            isSlotEmpty = value;
        }

        public static void SlotColorUpdate()
        {
            foreach (Slot slot in slots)
            {
                if (slot.isSlotEmpty)
                {
                    Effects.InsGreenSlotParticle(slot.GetSlotTrasnform(slot.GetSlotID()));
                }
                else
                {
                    Effects.InsRedSlotParticle(slot.GetSlotTrasnform(slot.GetSlotID()));
                }
            }
        }
       







    }
}

