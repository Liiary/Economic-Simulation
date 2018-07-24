using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventar : MonoBehaviour                 //SpielerInventar
{

    //public GameObject player;

    //public int spielerGeld;
    //public int spielerHolz;
    //public int spielerStein;
    //public int spielerMetal;

    //public Text spielerGeldText;
    //public Text spielerHolzText;
    //public Text spielerSteinText;
    //public Text spielerMetalText;
    //public Text AktivierungsText;

    public GameObject player;

    public int playerMoney;
    public int playerWood;
    public int playerStone;
    public int playerMetal;

    public Text PlayerMoneyText;
    public Text PlayerWoodText;
    public Text PlayerStoneText;
    public Text PlayerMetalText;
    public Text ActivationText;

    private void Start()
    {
        ActivationText.text = "";
    }

    private void Update()
    {
         
        PlayerMoneyText.text = "Money: " + playerMoney.ToString();
        PlayerWoodText.text = "Wood: " + playerWood.ToString();
        PlayerStoneText.text = "Stone: " + playerStone.ToString();
        PlayerMetalText.text = "Metal: " + playerMetal.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("bank"))
        {
            ActivationText.text = "Drücke E um das Geld einzusammeln.";
        }
        if (other.CompareTag("holzfäller"))
        {
            ActivationText.text = "Drücke E um das Holz einzusammeln";
        }
        if (other.CompareTag("steinmetz"))
        {
            ActivationText.text = "Drücke E um den Stein einzusammeln";
        }
        if (other.CompareTag("fabrik"))
        {
            ActivationText.text = "Drücke E um das Metall einzusammeln";
        }
        
        if (Input.GetKeyDown("e"))
        {

            if (other.CompareTag("bank"))
            {
                playerMoney = playerMoney + player.GetComponent<MoneyProduction>().Money;
                player.GetComponent<MoneyProduction>().Money = 0;
            }
            if (other.CompareTag("holzfäller"))
            {
                playerWood = playerWood + player.GetComponent<MoneyProduction>().Wood;
                player.GetComponent<MoneyProduction>().Wood = 0;
            }
            if (other.CompareTag("steinmetz"))
            {
                playerStone = playerStone + player.GetComponent<MoneyProduction>().Stone;
                player.GetComponent<MoneyProduction>().Stone = 0;
            }
            if (other.CompareTag("fabrik"))
            {
                playerMetal = playerMetal + player.GetComponent<MoneyProduction>().Metal;
                player.GetComponent<MoneyProduction>().Metal = 0;
            }  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ActivationText.text = "";
    }

}
