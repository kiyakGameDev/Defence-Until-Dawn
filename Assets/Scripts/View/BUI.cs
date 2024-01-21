using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.User;

namespace VUD_Project.View
{
    public class BUI : UserInterface
    {


        private void Start()
        {

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<BPlayer>();
            market = GameObject.FindGameObjectWithTag("Market").GetComponent<BMarket>();

            SetPriceTurret1(market.GetPriceTurret1());
            SetPriceTurret2(market.GetPriceTurret2());
            SetPriceTurret3(market.GetPriceTurret3());

            SetGoldQuantity(player.GetGold());

            openMarket_button.onClick.AddListener(OpenMarket_ButtonFunc);
            closeMarket_button.onClick.AddListener(CloseMarket_ButtonFunc);

            buyTurret1_button.onClick.AddListener(market.BuyTurret1);
            buyTurret2_button.onClick.AddListener(market.BuyTurret2);
            buyTurret3_button.onClick.AddListener(market.BuyTurret3);   




        }



    }
}

