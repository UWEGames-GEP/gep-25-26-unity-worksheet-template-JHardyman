using System.Runtime.CompilerServices;
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
    public GameObject InventoryUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
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
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
                InventoryUI.SetActive(true);
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

