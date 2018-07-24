using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bying : MonoBehaviour                  //Kaufen
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
    int levelMetalExpension;

    int workmenMoneyExpension;
    int workmenWoodExpension;
    int workmenStoneExpension;
    int workmenMetalExpension;

    int levelMoney;
    int levelWood;
    int levelStone;
    int levelMetal;

    int workmensMoney;
    int workmensWood;
    int workmensStone;
    int workmensMetal;

    public Text ExpensionMoneyText;
    public Text ExpensionWoodText;
    public Text ExpensionStoneText;
    public Text ExpensionMetalText;

    public Text WorkmenExpensionMoneyText;
    public Text WorkmenExpensionWoodText;
    public Text WorkmenExpensionStoneText;
    public Text WorkmenExpensionMetalText;

    public void UpgradeExpensionDisplay(int upgradeDisplayFabric)                  //UpgradeKostenAnzeige
    {
        
        if (upgradeDisplayFabric == 0)
        {
            
            ExpensionMoneyText.text = "Geld: " + levelMoneyExpension.ToString();
        }
        else if (upgradeDisplayFabric == 1)
        {
           
            ExpensionWoodText.text = "Holz: " + levelWoodExpension.ToString();
        }
        else if (upgradeDisplayFabric == 2)
        {
            
            ExpensionStoneText.text = "Stein: " + levelStoneExpension.ToString();
        }
        else if (upgradeDisplayFabric == 3)
        {
           
            ExpensionMetalText.text = "Metal: " + levelMetalExpension.ToString();
        }
    }

    public void WorkmenExpensionDisplay(int workmenDispayFabric)                        //ArbeiterKostenAnzeige
    {
        
        if (workmenDispayFabric == 0)
        {
            
            WorkmenExpensionMoneyText.text = "Geld: " + workmenMoneyExpension.ToString();
        }
        else if (workmenDispayFabric == 1)
        {
            
            WorkmenExpensionWoodText.text = "Holz: " + workmenWoodExpension.ToString();
        }
        else if (workmenDispayFabric == 2)
        {
            
            WorkmenExpensionStoneText.text = "Stein: " + workmenStoneExpension.ToString();
        }
        else if (workmenDispayFabric == 3)
        {
            
            WorkmenExpensionMetalText.text = "Metal: " + workmenMetalExpension.ToString();
        }
    }

    public void SubtractFabric(int subtractFabric,int expension,int workUpgrade)                    //int stoff, int kosten, int arbeitUpgrade
    {
        if (subtractFabric == 0)//Geld
        {
            inventar=player.GetComponent<PlayerInventar>().playerMoney;
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
            inventar = player.GetComponent<PlayerInventar>().playerMetal;
            inventar = inventar - expension;
            player.GetComponent<PlayerInventar>().playerMetal = inventar;
            
        }
        ExpensionAddition(subtractFabric,workUpgrade);
    }

    public void ExpensionAddition(int expensionAddFabric,int upgradeWorkmen)                   //KostenErhöhen (int stoff, int UpAr)
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
                levelMetalExpension = levelMetalExpension + 100 * levelMetal;
            }
            else
            {
                workmenMetalExpension = workmenMetalExpension + 100 * workmensMetal;
            }
        }
    }

    public void InventarHouseTest(int art)                   //InventarTestenHäuser
    {
            if(art == 0)
            {
                if (player.GetComponent<PlayerInventar>().playerMoney >= levelMoneyExpension)
                {
                    ByingHouses(art);
                    SubtractFabric(art, levelMoneyExpension, 1);
                    levelMoney++;
                    UpgradeExpensionDisplay(art);
                }
            }
            else if (art == 1)
            {
                if (player.GetComponent<PlayerInventar>().playerWood >= levelWoodExpension)
                {
                    ByingHouses(art);
                    SubtractFabric(art, levelWoodExpension, 1);
                    levelWood++;
                    UpgradeExpensionDisplay(art);
                }
            }
            else if (art == 2)
            {
                if (player.GetComponent<PlayerInventar>().playerStone>= levelStoneExpension)
                {
                    ByingHouses(art);
                    SubtractFabric(art, levelStoneExpension, 1);
                    levelStone++;
                    UpgradeExpensionDisplay(art);
                }
            }
            else if (art == 3)
            {
                if (player.GetComponent<PlayerInventar>().playerMetal >= levelMetalExpension)
                {
                    ByingHouses(art);
                    SubtractFabric(art, levelMetalExpension, 1);
                    levelMetal++;
                    UpgradeExpensionDisplay(art);
                }
            }
    }

    public void InventarWorkmenTest(int art)                 //InventarTestenArbeiter
    {
        if (art == 0)
        {
            if (player.GetComponent<PlayerInventar>().playerMoney >= workmenMoneyExpension)
            {
                ByingWorkmen(art);
                SubtractFabric(art, workmenMoneyExpension, 0);
                workmensMoney++;
                WorkmenExpensionDisplay(art);
            }
        }
        else if (art == 1)
        {
            if (player.GetComponent<PlayerInventar>().playerWood >= workmenWoodExpension)
            {
                ByingWorkmen(art);
                SubtractFabric(art, workmenWoodExpension, 0);
                workmensWood++;
                WorkmenExpensionDisplay(art);
            }
        }
        else if (art == 2)
        {
            if (player.GetComponent<PlayerInventar>().playerStone >= workmenStoneExpension)
            {
                ByingWorkmen(art);
                SubtractFabric(art, workmenStoneExpension, 0);
                workmensStone++;
                WorkmenExpensionDisplay(art);
            }
        }
        else if (art == 3)
        {
            if (player.GetComponent<PlayerInventar>().playerMetal >= workmenMetalExpension)
            {
                ByingWorkmen(art);
                SubtractFabric(art, workmenMetalExpension, 0);
                workmensMetal++;
                WorkmenExpensionDisplay(art);
            }
        }
    }

    public void ByingHouses(int byingHousesFabric)
    {
        player.GetComponent<MoneyProduction>().Extensions(byingHousesFabric);
    }

    public void ByingWorkmen(int byingWorkmenFabric)
    {
        player.GetComponent<MoneyProduction>().WorkmenByings(byingWorkmenFabric);
    }


}
