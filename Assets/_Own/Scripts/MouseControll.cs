using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    private CanvasManager canvasManager;

    private void Start()
    {
        canvasManager = GameObject.FindWithTag("GameManager").GetComponent<CanvasManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CompareTag("FarmHouse"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeFarmHouse.SetActive(true);
                Debug.Log("Collider FarmHouse");
            }

            if (CompareTag("Farm"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeFarm.SetActive(true);
                Debug.Log("Collider Farm");
            }

            if (CompareTag("House"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeHouse.SetActive(true);
                Debug.Log("Collider House");
            }

            if (CompareTag("Tower"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.UpgradeTower.SetActive(true);
                Debug.Log("Collider Tower");
            }

            if (CompareTag("Grass"))
            {
                canvasManager.Image.SetActive(true);
                canvasManager.NewBuilding.SetActive(true);
                Debug.Log("Collider Grass");
            }
        }
    }

    public void CloseCanvas()
    {
        canvasManager.UpgradeFarmHouse.SetActive(false);
        canvasManager.UpgradeFarm.SetActive(false);
        canvasManager.UpgradeHouse.SetActive(false);
        canvasManager.UpgradeTower.SetActive(false);
        canvasManager.NewBuilding.SetActive(false);
        canvasManager.Image.SetActive(false);
    }
}
