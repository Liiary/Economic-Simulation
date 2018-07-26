using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyProduction : MonoBehaviour                        //GeldProduzieren
{
    //public Text GeldText;
    //public Text HolzText;
    //public Text SteinText;
    //public Text MetalText;

    //public int Geld;
    //public int Holz;
    //public int Stein;
    //public int Metal;
    //public int zusatzGeld;
    //public int zusatzHolz;
    //public int zusatzStein;
    //public int zusatzMetal;
    //public int erweiterungenGeld = 0;
    //public int erweiterungenHolz = 0;
    //public int erweiterungenStein = 0;
    //public int erweiterungenMetal = 0;
    //public int ArbeiterGeld;
    //public int ArbeiterHolz;
    //public int ArbeiterStein;
    //public int ArbeiterMetal;

    //public Text verbesserungsText;

    //private BuildBuilding buildBuilding;
    //private UpgradeBuilding upgradeFarmHouse;
    //private UpgradeBuilding upgradeFarm;
    //private UpgradeBuilding upgradeHouse;
    //private UpgradeBuilding upgradeTower;
    //[SerializeField]
    //private GameObject farmHouse;
    //[SerializeField]
    //private GameObject farm;
    //[SerializeField]
    //private GameObject house;
    //[SerializeField]
    //private GameObject tower;

    public Text MoneyText;
    public Text WoodText;
    public Text StoneText;
    public Text MetalText;

    public int Money;
    public int Wood;
    public int Stone;
    public int Metal;
    public int extraMoney;
    public int extraWood;
    public int extraStone;
    public int extraMetal;
    public int LevelMoney;
    public int LevelWood;
    public int LevelStone;
    public int LevelMetal;
    public int workmenMoney;
    public int workmenWood;
    public int workmenStone;
    public int workmenMetal;

    private BuildBuilding buildBuilding;
    private UpgradeBuilding upgradeFarmHouse;
    private UpgradeBuilding upgradeFarm;
    private UpgradeBuilding upgradeHouse;
    private UpgradeBuilding upgradeTower;
    [SerializeField]
    private GameObject farmHouse;
    [SerializeField]
    private GameObject farm;
    [SerializeField]
    private GameObject house;
    [SerializeField]
    private GameObject tower;
    [SerializeField]
    private HouseScript choosenHouse;

    private void Start()
    {
        buildBuilding = GetComponent<BuildBuilding>();
        upgradeFarmHouse = farmHouse.GetComponent<UpgradeBuilding>();
        upgradeFarm = farm.GetComponent<UpgradeBuilding>();
        upgradeHouse = house.GetComponent<UpgradeBuilding>();
        upgradeTower = tower.GetComponent<UpgradeBuilding>();

        StartCoroutine(Print());
        StartCoroutine(Logging());
        StartCoroutine(Quarring());
        StartCoroutine(Forging());

        extraMoney++;
        extraWood++;
        extraStone++;
        extraMetal++;

        LevelMoney++;
        LevelWood++;
        LevelStone++;
        LevelMetal++;
    }

    private void Update()
    {
        MoneyText.text = "Money: " + Money.ToString();
        WoodText.text = "Wood: " + Wood.ToString();
        StoneText.text = "Stone: " + Stone.ToString();
        MetalText.text = "Metal: " + Metal.ToString();
    }

    public void AddMixtures(int addMixture)             //public void Zusätze(int stoff)
    {
        if (addMixture == 0)
        {
            buildBuilding.Build(addMixture);
            extraMoney++;
        }
        else if (addMixture == 1)
        {
            buildBuilding.Build(addMixture);
            extraWood++;
        }
        else if (addMixture == 2)
        {
            buildBuilding.Build(addMixture);
            extraStone++;
        }
        else if (addMixture == 3)
        {
            buildBuilding.Build(addMixture);
            extraMetal++;
        }
    }

    public void Extensions(int extension)                   //public void Erweiterungen(int stoff)
    {
        choosenHouse = MouseControll.ChoosenBuilding.GetComponent<HouseScript>();
        if (extension == 0)
        {
            upgradeFarmHouse.Upgrade(extension);
            LevelMoney++;
            if (choosenHouse.extensionMoney == 7)
            {
                choosenHouse.extensionMoney = 0;
                AddMixtures(extension);
            }
        }
        else if (extension == 1)
        {
            upgradeFarm.Upgrade(extension);
            LevelWood++;
            if (choosenHouse.extensionWood == 7)
            {
                choosenHouse.extensionWood = 0;
                AddMixtures(extension);
            }
        }
        else if (extension == 2)
        {
            upgradeHouse.Upgrade(extension);
            LevelStone++;
            if (choosenHouse.extensionStone == 7)
            {
                choosenHouse.extensionStone = 0;
                AddMixtures(extension);
            }
        }
        else if (extension == 3)
        {
            upgradeTower.Upgrade(extension);
            LevelMetal++;
            if (choosenHouse.extensionMetal == 7)
            {
                choosenHouse.extensionMetal = 0;
                AddMixtures(extension);
            }
        }
    }

    public void WorkmenByings(int workmenBying)                 //public void ArbeiterKaufen(int stoff)
    {
        if (workmenBying == 0)
        {
            workmenMoney++;
        }
        else if (workmenBying == 1)
        {
            workmenWood++;
        }
        else if (workmenBying == 2)
        {
            workmenStone++;
        }
        else if (workmenBying == 3)
        {
            workmenMetal++;
        }
    }

    IEnumerator Print()                   //Drucken
    {
        Money = Money + extraMoney * LevelMoney * workmenMoney;
        yield return new WaitForSeconds(1);
        StartCoroutine(Print());
    }
    IEnumerator Logging()                    //Fällen
    {
        Wood = Wood + extraWood * LevelWood * workmenWood;
        yield return new WaitForSeconds(1);
        StartCoroutine(Logging());
    }
    IEnumerator Quarring()                   //Abbauen
    {
        Stone = Stone + extraStone * LevelStone * workmenStone;
        yield return new WaitForSeconds(1);
        StartCoroutine(Quarring());
    }
    IEnumerator Forging()                 //Schmieden
    {
        Metal = Metal + extraMetal * LevelMetal * workmenMetal;
        yield return new WaitForSeconds(1);
        StartCoroutine(Forging());
    }
}
