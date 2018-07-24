using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    public static GameObject ChoosenBuilding;

    private MoneyProduction moneyProductIon;
    private CanvasManager canvasManager;

    private void Start()
    {
        moneyProductIon = GameObject.FindWithTag("GameManager").GetComponent<MoneyProduction>();
        canvasManager = GameObject.FindWithTag("GameManager").GetComponent<CanvasManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            canvasManager.Image.SetActive(true);
            canvasManager.NewBuilding.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            canvasManager.Shop.SetActive(true);
        }
    }

    private void OnMouseOver()
    {
        Ray ray;
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                ChoosenBuilding = hit.collider.gameObject;
            }

            if (CompareTag("FarmHouse"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeFarmHouse.SetActive(true);
            }

            else if (CompareTag("Farm"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeFarm.SetActive(true);
            }

            else if (CompareTag("House"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeHouse.SetActive(true);
            }

            else if (CompareTag("Tower"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeTower.SetActive(true);
            }

            else if (CompareTag("BuildingMax"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.MaxBuilding.SetActive(true);
            }
        }
    }

    public void CloseCanvas()
    {
        ChoosenBuilding = null;
        canvasManager.UpgradeFarmHouse.SetActive(false);
        canvasManager.UpgradeFarm.SetActive(false);
        canvasManager.UpgradeHouse.SetActive(false);
        canvasManager.UpgradeTower.SetActive(false);
        canvasManager.NewBuilding.SetActive(false);
        canvasManager.Image.SetActive(false);
        canvasManager.MaxBuilding.SetActive(false);
        canvasManager.Shop.SetActive(false);
    }

    public void UpgradeButton(int buildingNumber)
    {
        moneyProductIon.Extensions(buildingNumber);
    }
}
