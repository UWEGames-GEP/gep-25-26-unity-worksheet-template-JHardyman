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

        //check if game state is changed
        if (hasChangedState)
        {

            //Toggle hasChangedState
            hasChangedState = false;

            //apply behaviour based on new game state
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



    public void PauseGame()
    {
        //Checking current gamestate
        if (state == GameState.GAMEPLAY)
        {
            //Toggle state over return key
            state = GameState.PAUSE;
            hasChangedState = true;
        }
        else if (state == GameState.PAUSE)
        {
            //Toggle state over the return key
            state = GameState.GAMEPLAY;
            hasChangedState = true;
        }
    }


}

