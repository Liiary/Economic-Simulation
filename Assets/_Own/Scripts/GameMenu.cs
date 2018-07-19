using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameRules;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameRules.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ContinueGame()
    {
        gameMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
