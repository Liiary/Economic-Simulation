using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    public static bool canvasOn;
    public static GameObject ChoosenBuilding;

    private bool gameRules;
    private MoneyProduction moneyProduction;
    private CanvasManager canvasManager;

    private void Start()
    {
        Time.timeScale = 0;
        canvasOn = false;
        moneyProduction = GameObject.FindWithTag("GameManager").GetComponent<MoneyProduction>();
        canvasManager = GameObject.FindWithTag("GameManager").GetComponent<CanvasManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            canvasManager.GameRules.SetActive(false);
            Time.timeScale = 1;
            gameRules = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasManager.PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (!canvasOn)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                canvasOn = true;
                canvasManager.Image.SetActive(true);
                canvasManager.NewBuilding.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                canvasOn = true;
                canvasManager.Shop.SetActive(true);
            }
        }
    }

    private void OnMouseOver()
    {
        Ray ray;
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (!canvasOn)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    ChoosenBuilding = hit.collider.gameObject;
                }

                if (CompareTag("FarmHouse"))
                {
                    canvasOn = true;
                    canvasManager.Image.SetActive(true);
                    canvasManager.UpgradeFarmHouse.SetActive(true);
                }

                else if (CompareTag("Farm"))
                {
                    canvasOn = true;
                    canvasManager.Image.SetActive(true);
                    canvasManager.UpgradeFarm.SetActive(true);
                }

                else if (CompareTag("House"))
                {
                    canvasOn = true;
                    canvasManager.Image.SetActive(true);
                    canvasManager.UpgradeHouse.SetActive(true);
                }

                else if (CompareTag("Tower"))
                {
                    canvasOn = true;
                    canvasManager.Image.SetActive(true);
                    canvasManager.UpgradeTower.SetActive(true);
                }

                else if (CompareTag("BuildingMax"))
                {
                    canvasOn = true;
                    canvasManager.Image.SetActive(true);
                    canvasManager.MaxBuilding.SetActive(true);
                }
            }
        }
    }

    public void ClosePauseMenu()
    {
        canvasManager.PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseCanvas()
    {
        canvasOn = false;
        ChoosenBuilding = null;
        canvasManager.UpgradeFarmHouse.SetActive(false);
        canvasManager.UpgradeFarm.SetActive(false);
        canvasManager.UpgradeHouse.SetActive(false);
        canvasManager.UpgradeTower.SetActive(false);
        canvasManager.NewBuilding.SetActive(false);
        canvasManager.Image.SetActive(false);
        canvasManager.MaxBuilding.SetActive(false);
        canvasManager.Shop.SetActive(false);
        canvasManager.GetResources.SetActive(false);
    }
}
