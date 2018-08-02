using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyProduction : MonoBehaviour                        //GeldProduzieren
{
    public Text MoneyText;
    public Text WoodText;
    public Text StoneText;
    public Text HayText;

    public int Money;
    public int Wood;
    public int Stone;
    public int Hay;
    public int extraMoney;
    public int extraWood;
    public int extraStone;
    public int extraHay;
    public int LevelMoney;
    public int LevelWood;
    public int LevelStone;
    public int LevelHay;
    public int workmenMoney;
    public int workmenWood;
    public int workmenStone;
    public int workmenHay;

    private CanvasManager canvasManager;
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
        canvasManager = GameObject.FindWithTag("GameManager").GetComponent<CanvasManager>();

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
        extraHay++;

        LevelMoney++;
        LevelWood++;
        LevelStone++;
        LevelHay++;
    }

    private void Update()
    {
        MoneyText.text = "Money: " + Money.ToString();
        WoodText.text = "Wood: " + Wood.ToString();
        StoneText.text = "Stone: " + Stone.ToString();
        HayText.text = "Hay: " + Hay.ToString();
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
            extraHay++;
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
                MouseControll.canvasOn = false;
                canvasManager.Image.SetActive(false);
                canvasManager.UpgradeFarmHouse.SetActive(false);
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
                MouseControll.canvasOn = false;
                canvasManager.Image.SetActive(false);
                canvasManager.UpgradeFarm.SetActive(false);
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
                MouseControll.canvasOn = false;
                canvasManager.Image.SetActive(false);
                canvasManager.UpgradeHouse.SetActive(false);
                choosenHouse.extensionStone = 0;
                AddMixtures(extension);
            }
        }
        else if (extension == 3)
        {
            upgradeTower.Upgrade(extension);
            LevelHay++;
            if (choosenHouse.extensionHay == 7)
            {
                MouseControll.canvasOn = false;
                canvasManager.Image.SetActive(false);
                canvasManager.UpgradeTower.SetActive(false);
                choosenHouse.extensionHay = 0;
                AddMixtures(extension);
            }
        }
    }

    public void WorkmenBuyings(int workmenBuying)                 //public void ArbeiterKaufen(int stoff)
    {
        if (workmenBuying == 0)
        {
            workmenMoney++;
        }
        else if (workmenBuying == 1)
        {
            workmenWood++;
        }
        else if (workmenBuying == 2)
        {
            workmenStone++;
        }
        else if (workmenBuying == 3)
        {
            workmenHay++;
        }
    }

    public void NewBuilding(int building)
    {
        if (building == 0)
        {
            AddMixtures(building);
            LevelMoney++;
        }
        else if (building == 1)
        {
            AddMixtures(building);
            LevelWood++;
        }
        else if (building == 2)
        {
            AddMixtures(building);
            LevelStone++;
        }
        else if (building == 3)
        {
            AddMixtures(building);
            LevelHay++;
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
        Hay = Hay + extraHay * LevelHay * workmenHay;
        yield return new WaitForSeconds(1);
        StartCoroutine(Forging());
    }
}
