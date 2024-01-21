using UnityEngine;
using VUD_Project.Data;
using VUD_Project.User;


namespace VUD_Project.View
{
    public class BSlot : Slot
    {
        private void Awake()
        {
            SlotID = GenerateSlotID();
            GameLogic.slotDictionary.Add(SlotID, this);
            slots.Add(this);
        }


        private void Start()
        {
            isSlotEmpty = true;
        }

    }
}

