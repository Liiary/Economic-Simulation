using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : MonoBehaviour
{
    private HouseScript choosenHouse;
    private MoneyProduction moneyProduction;
    private GameObject gameManager;

    [SerializeField]
    private GameObject upgradeFarmHouseCanvas;
    [SerializeField]
    private GameObject upgradeFarmCanvas;
    [SerializeField]
    private GameObject upgradeHouseCanvas;
    [SerializeField]
    private GameObject upgradeTowerCanvas;

    public void Upgrade(int buildingNumber)
    {
        if(gameManager == null)
            gameManager = GameObject.FindWithTag("GameManager");

        if (moneyProduction == null)
            moneyProduction = gameManager.GetComponent<MoneyProduction>();

        if (buildingNumber == 0)
        {
            //GameObject farmHouse = GameObject.FindWithTag("FarmHouse");
            GameObject farmHouse = MouseControll.ChoosenBuilding.gameObject;
            choosenHouse = MouseControll.ChoosenBuilding.GetComponent<HouseScript>();

            if (choosenHouse.extensionMoney >= 6)
            {
                choosenHouse.extensionMoney++;
                farmHouse.transform.gameObject.tag = "BuildingMax";
            }
            else
            {
                farmHouse.transform.GetChild(choosenHouse.extensionMoney).GetComponent<MeshRenderer>().enabled = false;
                choosenHouse.extensionMoney++;
                farmHouse.transform.GetChild(choosenHouse.extensionMoney).GetComponent<MeshRenderer>().enabled = true;
            }

        }

        if (buildingNumber == 1)
        {
            //GameObject farm = GameObject.FindWithTag("Farm");
            GameObject farm = MouseControll.ChoosenBuilding.gameObject;
            choosenHouse = MouseControll.ChoosenBuilding.GetComponent<HouseScript>();

            if (choosenHouse.extensionWood >= 6)
            {
                choosenHouse.extensionWood++;
                farm.transform.gameObject.tag = "BuildingMax";
            }
            else
            {
                farm.transform.GetChild(choosenHouse.extensionWood).GetComponent<MeshRenderer>().enabled = false;
                choosenHouse.extensionWood++;
                farm.transform.GetChild(choosenHouse.extensionWood).GetComponent<MeshRenderer>().enabled = true;
            }
        }


        if(buildingNumber == 2)
        {
            //GameObject house = GameObject.FindWithTag("House");
            GameObject house = MouseControll.ChoosenBuilding.gameObject;
            choosenHouse = MouseControll.ChoosenBuilding.GetComponent<HouseScript>();

            if (choosenHouse.extensionStone >= 6)
            {
                choosenHouse.extensionStone++;
                house.transform.gameObject.tag = "BuildingMax";
            }
            else
            {
                house.transform.GetChild(choosenHouse.extensionStone).GetComponent<MeshRenderer>().enabled = false;
                choosenHouse.extensionStone++;
                house.transform.GetChild(choosenHouse.extensionStone).GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if(buildingNumber == 3)
        {
            //GameObject tower = GameObject.FindWithTag("Tower");
            GameObject tower = MouseControll.ChoosenBuilding.gameObject;
            choosenHouse = MouseControll.ChoosenBuilding.GetComponent<HouseScript>();

            if (choosenHouse.extensionHay >= 6)
            {
                choosenHouse.extensionHay++;
                tower.transform.gameObject.tag = "BuildingMax";
            }
            else
            {
                tower.transform.GetChild(choosenHouse.extensionHay).GetComponent<MeshRenderer>().enabled = false;
                choosenHouse.extensionHay++;
                tower.transform.GetChild(choosenHouse.extensionHay).GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
