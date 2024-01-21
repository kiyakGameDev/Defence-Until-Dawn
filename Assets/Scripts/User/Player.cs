using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;
using VUD_Project.View;

namespace VUD_Project.User
{
    
    public class Player : MonoBehaviour
    {

        //Connections
        protected Market market;
       

        //Settings
        protected int maxHealth = 100;
        protected int initialGold = 80;

       

        //Value
        protected int currentHealth;
        protected int gold;



        //Get-Set functions
        public int GetHealth() 
        {
            return currentHealth;
        }
        public void SetHealth(int value) 
        {
            currentHealth = value;
        }
        public int GetGold()  
        {
            return gold;
        }
        public void SetGold(int value) 
        {
            gold = value;
        }





        //Game
        public void RayCastSlotTouch() 
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                RaycastHit hit;  

                if (Physics.Raycast(ray, out hit)) 
                {
                   if (hit.collider.GetComponent<BSlot>())
                   {
                       if (market.GetIHaveWeaponValue())
                        {
                            BSlot slot = hit.collider.GetComponent<BSlot>();
                            if (slot.GetSlotEmptyValue())
                            {
                                GameLogic.GetFolderPositionTurrets();
                                if (market.GetTurretEnum() == TurretType.turret1)
                                    GameLogic.CreateTurret(GameLogic.turret1, slot.GetSlotTrasnform(slot.GetSlotID()));
                                if (market.GetTurretEnum() == TurretType.turret2)
                                    GameLogic.CreateTurret(GameLogic.turret2, slot.GetSlotTrasnform(slot.GetSlotID()));
                                if (market.GetTurretEnum() == TurretType.turret3)
                                    GameLogic.CreateTurret(GameLogic.turret3, slot.GetSlotTrasnform(slot.GetSlotID()));
                                Effects.PlayPutSound();
                                market.SetIHaveWeaponValue(false);
                                slot.SetSlotEmptyValue(false);

                                Effects.KillAllParticles();
                                Effects.TurretPutParticle(slot.GetSlotTrasnform(slot.GetSlotID()));
                            }
                            else
                            {
                                Effects.PlayErrorSound();
                            }
                          
                        }
                   }
                }
            }
        }

        public void ChangeHealth(int damage)
        {
            if (currentHealth > 0)
            {
                currentHealth -= damage;
                
            }
            else
            {
                //Game Over
            }

        }







    }
}

