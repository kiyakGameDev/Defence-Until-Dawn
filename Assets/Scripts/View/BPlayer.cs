using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;
using VUD_Project.User;

namespace VUD_Project.View
{
    public class BPlayer : Player
    {


       

        private void Start()
        {
            market = GameObject.FindGameObjectWithTag("Market").GetComponent<BMarket>();
            

            currentHealth = maxHealth;
            gold = initialGold;



           
        }


        private void Update()
        {
            RayCastSlotTouch();
        }




    }
}

