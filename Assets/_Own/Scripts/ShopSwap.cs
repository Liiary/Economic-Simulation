using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSwap : MonoBehaviour                   //LadenSwap
{

    //public GameObject BankSeite;
    //public GameObject FabrikSeite;
    //public GameObject HolzfällerSeite;
    //public GameObject LaborSeite;
    //public GameObject SteinmetzSeite;

    //public int seite=1;
    //bool imLaden=true;

    public GameObject BankSide;
    public GameObject FactorySide;
    public GameObject WoodpackerSide;
    public GameObject LaboratorySide;
    public GameObject StonecutterSide;

    public int side = 1;
    bool inShop = true;

    public void Turning()                  //Umdrehen
    {
        side = side + 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && inShop == true)
        {
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inShop = true;
        }
    }

    private void Update()
    {
        if (side == 1)
        {
            StonecutterSide.SetActive(false);
            BankSide.SetActive(true);
        }
        else if (side == 2)
        {
            BankSide.SetActive(false);
            FactorySide.SetActive(true);
        }
        else if(side == 3)
        {
            FactorySide.SetActive(false);
            WoodpackerSide.SetActive(true);
        }
        else if(side == 4)
        {
            WoodpackerSide.SetActive(false);
            LaboratorySide.SetActive(true);
        }
        else if(side == 5)
        {
            LaboratorySide.SetActive(false);
            StonecutterSide.SetActive(true);
            side = 0;
        }
    }

    public void SchließeLaden()
    {
        inShop = false;
        Time.timeScale = 1;
    }

}
