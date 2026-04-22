using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerAdd : MonoBehaviour
{
    public enum GameState
    {
        GAMEPLAY,
        PAUSE
    }

    public GameState state;
    public bool hasChangedState;
    public InventoryScript Inventory;
    public GameObject InventoryUI;
    public GameObject InventoryPanel;


    void Start()
    {
        state = GameState.GAMEPLAY;
        InventoryUI.SetActive(false);
    }



    private void LateUpdate()
    {

        if (hasChangedState)
        {

            hasChangedState = false;

            if (state == GameState.GAMEPLAY)
            {
                Time.timeScale = 1.0f;
                InventoryUI.SetActive(false);
                InventoryPanel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
                InventoryUI.SetActive(true);
                InventoryPanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void Update()
    {
        
    }

    public void PauseGame()
    {
        switch (state)
        {
            case GameState.GAMEPLAY:
                state = GameState.PAUSE;

                hasChangedState = true;
                break;
            case GameState.PAUSE:
                state = GameState.GAMEPLAY;
                hasChangedState = true;
                break;
        }

    }


}

