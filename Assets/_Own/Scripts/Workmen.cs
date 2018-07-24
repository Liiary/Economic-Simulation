using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workmen : MonoBehaviour                    //Hanwerker
{
    public GameObject player;
    public GameObject shop;                     //laden

    private void Start()
    {
        var inv = player.GetComponent<PlayerInventar>();
        var pro = player.GetComponent<MoneyProduction>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shop.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shop.SetActive(false);
        }
    }

}
