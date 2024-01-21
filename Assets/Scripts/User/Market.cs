using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUD_Project.Data;

namespace VUD_Project.User
{
    public enum TurretType {turret1, turret2, turret3}
    public class Market : MonoBehaviour
    {
        //Conenctions
        protected Player player;
        protected UserInterface userInterface;
        //Settings
        protected int priceTurret1 = 10;
        protected int priceTurret2 = 20;
        protected int priceTurret3 = 35;


        //Value
        protected bool IhaveWeapon;
        protected TurretType turret;

        //Set-Get functions
        public void SetIHaveWeaponValue(bool value)
        {
            IhaveWeapon = value;
        }

        public bool GetIHaveWeaponValue()
        {
            return IhaveWeapon;
        }
        public void SetPriceTurret1(int value)
        {
            priceTurret1 = value;
        }
        public void SetPriceTurret2(int value)
        {
            priceTurret1 = value;
        }
        public void SetPriceTurret3(int value)
        {
            priceTurret3 = value;
        }
        public int GetPriceTurret1()
        {
            return priceTurret1;
        }
        public int GetPriceTurret2()
        {
            return priceTurret2;
        }
        public int GetPriceTurret3()
        {
            return priceTurret3;
        }

        public TurretType GetTurretEnum()
        {
            return turret;
        }
        public void SetTurretEnum(TurretType value)
        {
            turret = value;
        }

        //Buy Func

        public void BuyTurret1()
        {
            if(player.GetGold()>= priceTurret1)
            {
                userInterface.CloseMarket_ButtonFunc();
                SetIHaveWeaponValue(true);
                player.SetGold(player.GetGold() - priceTurret1);
                userInterface.SetGoldQuantity(player.GetGold());
                SetTurretEnum(TurretType.turret1);
                Slot.SlotColorUpdate();
                Effects.PlayMouseClick();
            }
            else
            {
                userInterface.SetErrorMessage("NOT ENOUGH GOLD");
                userInterface.OpenErrorMessageText();
                Effects.PlayErrorSound();

            }
        }
        public void BuyTurret2()
        {
            if (player.GetGold() >= priceTurret2)
            {
                userInterface.CloseMarket_ButtonFunc();
                SetIHaveWeaponValue(true);
                player.SetGold(player.GetGold() - priceTurret2);
                userInterface.SetGoldQuantity(player.GetGold());
                SetTurretEnum(TurretType.turret2);
                Slot.SlotColorUpdate();
                Effects.PlayMouseClick();
            }
            else
            {
                userInterface.SetErrorMessage("NOT ENOUGH GOLD");
                userInterface.OpenErrorMessageText();
                Effects.PlayErrorSound();
            }
        }
        public void BuyTurret3()
        {
            if (player.GetGold() >= priceTurret3)
            {
                userInterface.CloseMarket_ButtonFunc();
                SetIHaveWeaponValue(true);
                player.SetGold(player.GetGold() - priceTurret3);
                userInterface.SetGoldQuantity(player.GetGold());
                SetTurretEnum(TurretType.turret3);
                Slot.SlotColorUpdate();
                Effects.PlayMouseClick();
            }
            else
            {
                userInterface.SetErrorMessage("NOT ENOUGH GOLD");
                userInterface.OpenErrorMessageText();
                Effects.PlayErrorSound();
            }
        }

    }

}
