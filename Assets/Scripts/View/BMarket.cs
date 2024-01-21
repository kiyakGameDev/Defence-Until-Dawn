using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.User;


namespace VUD_Project.View
{
    public class BMarket : Market
    {



        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<BPlayer>();
            userInterface = GameObject.FindGameObjectWithTag("UserInterface").GetComponent<BUI>();


            IhaveWeapon = false;
        }
    }

}
