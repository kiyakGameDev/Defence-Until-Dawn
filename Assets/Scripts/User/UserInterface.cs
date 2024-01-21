using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VUD_Project.Data;

namespace VUD_Project.User
{
    public class UserInterface : MonoBehaviour
    {

        //Connections
        protected Market market;
        protected Player player;


        //Settings
        [SerializeField] protected GameObject marketPanel_GameObject;
        [SerializeField] protected Button openMarket_button;
        [SerializeField] protected Button closeMarket_button;

        [SerializeField] protected Button buyTurret1_button;
        [SerializeField] protected Button buyTurret2_button;
        [SerializeField] protected Button buyTurret3_button;

        [SerializeField] protected TextMeshProUGUI priceTurret1_tmp;
        [SerializeField] protected TextMeshProUGUI priceTurret2_tmp;
        [SerializeField] protected TextMeshProUGUI priceTurret3_tmp;

        [SerializeField] protected TextMeshProUGUI gold_tmp;
        [SerializeField] protected GameObject goldArea;
        [SerializeField] protected GameObject marketButtonArea;
        [SerializeField] protected TextMeshProUGUI error_tmp;

        





        //Open-Close Market Func
        public void OpenMarket_ButtonFunc()
        {
            marketPanel_GameObject.SetActive(true);
            goldArea.SetActive(false);
            marketButtonArea.SetActive(false);
            Effects.PlayMouseClick();
        }
        public void CloseMarket_ButtonFunc()
        {
            marketPanel_GameObject.SetActive(false);
            goldArea.SetActive(true);
            marketButtonArea.SetActive(true);
            Effects.PlayMouseClick();
        }


       


        //Set price Texts
        public void SetPriceTurret1(int value)
        {
            priceTurret1_tmp.text = value.ToString();
        }
        public void SetPriceTurret2(int value)
        {
            priceTurret2_tmp.text = value.ToString();
        }
        public void SetPriceTurret3(int value)
        {
            priceTurret3_tmp.text = value.ToString();
        }
        public void SetGoldQuantity(int value)
        {
            gold_tmp.text = value.ToString();
        }


        //Write Error Message

        public void SetErrorMessage(string value)
        {
            error_tmp.text = value;
        }



        //Open-Close Error Messages
        public void OpenErrorMessageText()
        {
            error_tmp.gameObject.SetActive(true);
            Invoke("CloseErrorMessageText", 2f);
        }
        public void CloseErrorMessageText()
        {
            error_tmp.gameObject.SetActive(false);
        }





    }

}
