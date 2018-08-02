using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventar : MonoBehaviour                 //SpielerInventar
{
    public GameObject player;

    public int playerMoney;
    public int playerWood;
    public int playerStone;
    public int playerHay;

    public Text PlayerMoneyText;
    public Text PlayerWoodText;
    public Text PlayerStoneText;
    public Text PlayerHayText;

    public CanvasManager canvasManager;

    private void Start()
    {
        canvasManager = GameObject.FindWithTag("GameManager").GetComponent<CanvasManager>();
    }

    private void Update()
    {      
        PlayerMoneyText.text = "Money: " + playerMoney.ToString();
        PlayerWoodText.text = "Wood: " + playerWood.ToString();
        PlayerStoneText.text = "Stone: " + playerStone.ToString();
        PlayerHayText.text = "Hay: " + playerHay.ToString();

        if (!MouseControll.canvasOn)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                MouseControll.canvasOn = true;
                canvasManager.GetResources.SetActive(true);
            }
        }
    }

    public void ResourcesToPlayer(int resource)
    {
        if(resource == 0)
        {
                playerMoney = playerMoney + player.GetComponent<MoneyProduction>().Money;
                player.GetComponent<MoneyProduction>().Money = 0;
        }
        else if(resource == 1)
        {
                playerWood = playerWood + player.GetComponent<MoneyProduction>().Wood;
                player.GetComponent<MoneyProduction>().Wood = 0;
        }
        else if(resource == 2)
        {
                playerStone = playerStone + player.GetComponent<MoneyProduction>().Stone;
                player.GetComponent<MoneyProduction>().Stone = 0;
        }
        else if(resource == 3)
        {
                playerHay = playerHay + player.GetComponent<MoneyProduction>().Hay;
                player.GetComponent<MoneyProduction>().Hay = 0;
        }
    }
}
