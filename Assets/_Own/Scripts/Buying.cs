using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buying : MonoBehaviour                  //Kaufen
{
    //public GameObject player;

    //int inventar;
    //int multiplikator;
    //int bauKosten;
    //int typ;

    //int stufeGeldKosten;
    //int stufeHolzKosten;
    //int stufeSteinKosten;
    //int stufeMetalKosten;

    //int arbeiterGeldKosten;
    //int arbeiterHolzKosten;
    //int arbeiterSteinKosten;
    //int arbeiterMetalKosten;

    //int stufeGeld;
    //int stufeHolz;
    //int stufeStein;
    //int stufeMetal;

    //int arbeiterGeld;
    //int arbeiterHolz;
    //int arbeiterStein;
    //int arbeiterMetal;

    //public Text KostenTextGeld;
    //public Text KostenTextHolz;
    //public Text KostenTextStein;
    //public Text KostenTextMetal;

    //public Text KostenTextGeldArbeiter;
    //public Text KostenTextHolzArbeiter;
    //public Text KostenTextSteinArbeiter;
    //public Text KostenTextMetalArbeiter;

    public GameObject player;

    int inventar;
    int multiplyer;
    int constuctionCoast;
    int typ;

    int levelMoneyExpension;
    int levelWoodExpension;
    int levelStoneExpension;
    int levelHayExpension;

    int workmenMoneyExpension;
    int workmenWoodExpension;
    int workmenStoneExpension;
    int workmenHayExpension;

    int levelMoney;
    int levelWood;
    int levelStone;
    int levelHay;

    int workmensMoney;
    int workmensWood;
    int workmensStone;
    int workmensHay;

    public Text ExpensionMoneyText;
    public Text ExpensionWoodText;
    public Text ExpensionStoneText;
    public Text ExpensionHayText;

    public Text NewFarmHouseText;
    public Text NewFarmText;
    public Text NewHouseText;
    public Text NewTowerText;

    public Text WorkmenExpensionMoneyText;
    public Text WorkmenExpensionWoodText;
    public Text WorkmenExpensionStoneText;
    public Text WorkmenExpensionHayText;

    public void UpdateExpensionDisplay(int upgradeDisplayFabric)                  //UpgradeKostenAnzeige
    {
        if (upgradeDisplayFabric == 0)
        {
            ExpensionMoneyText.text = "Money: " + levelMoneyExpension.ToString();
        }
        else if (upgradeDisplayFabric == 1)
        {
            ExpensionWoodText.text = "Wood: " + levelWoodExpension.ToString();
        }
        else if (upgradeDisplayFabric == 2)
        {
            ExpensionStoneText.text = "Stone: " + levelStoneExpension.ToString();
        }
        else if (upgradeDisplayFabric == 3)
        {
            ExpensionHayText.text = "Hay: " + levelHayExpension.ToString();
        }
    }

    public void UpdateNewBuildingDisplay(int updateDisplay)
    {
        if (updateDisplay == 0)
        {
            NewFarmHouseText.text = "Money: " + levelMoneyExpension.ToString();
        }
        else if (updateDisplay == 1)
        {
            NewFarmText.text = "Wood: " + levelWoodExpension.ToString();
        }
        else if (updateDisplay == 2)
        {
            NewHouseText.text = "Stone: " + levelStoneExpension.ToString();
        }
        else if (updateDisplay == 3)
        {
            NewTowerText.text = "Hay: " + levelHayExpension.ToString();
        }
    }

    public void WorkmenExpensionDisplay(int workmenDispayFabric)                        //ArbeiterKostenAnzeige
    {
        if (workmenDispayFabric == 0)
        {
            WorkmenExpensionMoneyText.text = "Money: " + workmenMoneyExpension.ToString();
        }
        else if (workmenDispayFabric == 1)
        {
            WorkmenExpensionWoodText.text = "Wood: " + workmenWoodExpension.ToString();
        }
        else if (workmenDispayFabric == 2)
        {
            WorkmenExpensionStoneText.text = "Stone: " + workmenStoneExpension.ToString();
        }
        else if (workmenDispayFabric == 3)
        {
            WorkmenExpensionHayText.text = "Hay: " + workmenHayExpension.ToString();
        }
    }

    public void SubtractFabric(int subtractFabric, int expension, int workUpgrade)                    //int stoff, int kosten, int arbeitUpgrade
    {
        if (subtractFabric == 0)//Geld
        {
            inventar = player.GetComponent<PlayerInventar>().playerMoney;
            inventar = inventar - expension;
            player.GetComponent<PlayerInventar>().playerMoney = inventar;

        }
        else if (subtractFabric == 1)//Holz
        {
            inventar = player.GetComponent<PlayerInventar>().playerWood;
            inventar = inventar - expension;
            player.GetComponent<PlayerInventar>().playerWood = inventar;

        }
        else if (subtractFabric == 2)//Stein
        {
            inventar = player.GetComponent<PlayerInventar>().playerStone;
            inventar = inventar - expension;
            player.GetComponent<PlayerInventar>().playerStone = inventar;

        }
        else if (subtractFabric == 3)//Metal
        {
            inventar = player.GetComponent<PlayerInventar>().playerHay;
            inventar = inventar - expension;
            player.GetComponent<PlayerInventar>().playerHay = inventar;

        }
        ExpensionAddition(subtractFabric, workUpgrade);
    }

    public void ExpensionAddition(int expensionAddFabric, int upgradeWorkmen)                   //KostenErhöhen (int stoff, int UpAr)
    {
        if (expensionAddFabric == 0)
        {
            if (upgradeWorkmen == 1)
            {
                levelMoneyExpension = levelMoneyExpension + 100 * levelMoney;
            }
            else
            {
                workmenMoneyExpension = workmenMoneyExpension + 100 * workmensMoney;
            }
        }
        else if (expensionAddFabric == 1)
        {
            if (upgradeWorkmen == 1)
            {
                levelWoodExpension = levelWoodExpension + 100 * levelWood;
            }
            else
            {
                workmenWoodExpension = workmenWoodExpension + 100 * workmensWood;
            }
        }
        else if (expensionAddFabric == 2)
        {
            if (upgradeWorkmen == 1)
            {
                levelStoneExpension = levelStoneExpension + 100 * levelStone;
            }
            else
            {
                workmenStoneExpension = workmenStoneExpension + 100 * workmensStone;
            }
        }
        else if (expensionAddFabric == 3)
        {
            if (upgradeWorkmen == 1)
            {
                levelHayExpension = levelHayExpension + 100 * levelHay;
            }
            else
            {
                workmenHayExpension = workmenHayExpension + 100 * workmensHay;
            }
        }
    }

    public void InventarHouseTest(int art)                   //InventarTestenHäuser
    {
        if (art == 0)
        {
            if (player.GetComponent<PlayerInventar>().playerMoney >= levelMoneyExpension)
            {
                BuyingHouses(art);
                SubtractFabric(art, levelMoneyExpension, 1);
                levelMoney++;
                UpdateExpensionDisplay(art);
                UpdateNewBuildingDisplay(art);
            }
        }
        else if (art == 1)
        {
            if (player.GetComponent<PlayerInventar>().playerWood >= levelWoodExpension)
            {
                BuyingHouses(art);
                SubtractFabric(art, levelWoodExpension, 1);
                levelWood++;
                UpdateExpensionDisplay(art);
                UpdateNewBuildingDisplay(art);
            }
        }
        else if (art == 2)
        {
            if (player.GetComponent<PlayerInventar>().playerStone >= levelStoneExpension)
            {
                BuyingHouses(art);
                SubtractFabric(art, levelStoneExpension, 1);
                levelStone++;
                UpdateExpensionDisplay(art);
                UpdateNewBuildingDisplay(art);
            }
        }
        else if (art == 3)
        {
            if (player.GetComponent<PlayerInventar>().playerHay >= levelHayExpension)
            {
                BuyingHouses(art);
                SubtractFabric(art, levelHayExpension, 1);
                levelHay++;
                UpdateExpensionDisplay(art);
                UpdateNewBuildingDisplay(art);
            }
        }
    }

    public void InventarWorkmenTest(int art)                 //InventarTestenArbeiter
    {
        if (art == 0)
        {
            if (player.GetComponent<PlayerInventar>().playerMoney >= workmenMoneyExpension)
            {
                BuyingWorkmen(art);
                SubtractFabric(art, workmenMoneyExpension, 0);
                workmensMoney++;
                WorkmenExpensionDisplay(art);
            }
        }
        else if (art == 1)
        {
            if (player.GetComponent<PlayerInventar>().playerWood >= workmenWoodExpension)
            {
                BuyingWorkmen(art);
                SubtractFabric(art, workmenWoodExpension, 0);
                workmensWood++;
                WorkmenExpensionDisplay(art);
            }
        }
        else if (art == 2)
        {
            if (player.GetComponent<PlayerInventar>().playerStone >= workmenStoneExpension)
            {
                BuyingWorkmen(art);
                SubtractFabric(art, workmenStoneExpension, 0);
                workmensStone++;
                WorkmenExpensionDisplay(art);
            }
        }
        else if (art == 3)
        {
            if (player.GetComponent<PlayerInventar>().playerHay >= workmenHayExpension)
            {
                BuyingWorkmen(art);
                SubtractFabric(art, workmenHayExpension, 0);
                workmensHay++;
                WorkmenExpensionDisplay(art);
            }
        }
    }

    public void BuyingNewBuildingText(int art)
    {
        if (art == 0)
        {
            if (player.GetComponent<PlayerInventar>().playerMoney >= levelMoneyExpension)
            {
                BuyingNewBuildings(art);
                SubtractFabric(art, levelMoneyExpension, 1);
                levelMoney++;
                UpdateNewBuildingDisplay(art);
                UpdateExpensionDisplay(art);
            }
        }
        else if (art == 1)
        {
            if (player.GetComponent<PlayerInventar>().playerWood >= levelWoodExpension)
            {
                BuyingNewBuildings(art);
                SubtractFabric(art, levelWoodExpension, 1);
                levelWood++;
                UpdateNewBuildingDisplay(art);
                UpdateExpensionDisplay(art);
            }
        }
        else if (art == 2)
        {
            if (player.GetComponent<PlayerInventar>().playerStone >= levelStoneExpension)
            {
                BuyingNewBuildings(art);
                SubtractFabric(art, levelStoneExpension, 1);
                levelStone++;
                UpdateNewBuildingDisplay(art);
                UpdateExpensionDisplay(art);
            }
        }
        else if (art == 3)
        {
            if (player.GetComponent<PlayerInventar>().playerHay >= levelHayExpension)
            {
                BuyingNewBuildings(art);
                SubtractFabric(art, levelHayExpension, 1);
                levelHay++;
                UpdateNewBuildingDisplay(art);
                UpdateExpensionDisplay(art);
            }
        }
    }

    public void BuyingNewBuildings(int buyingBuildingFabric)
    {
        player.GetComponent<MoneyProduction>().NewBuilding(buyingBuildingFabric);
    }

    public void BuyingHouses(int buyingHousesFabric)
    {
        player.GetComponent<MoneyProduction>().Extensions(buyingHousesFabric);
    }

    public void BuyingWorkmen(int buyingWorkmenFabric)
    {
        player.GetComponent<MoneyProduction>().WorkmenBuyings(buyingWorkmenFabric);
    }
}
