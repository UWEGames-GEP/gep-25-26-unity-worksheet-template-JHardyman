using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerCharacterController : ThirdPersonController
{
    public GameManagerAdd gameManager;

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            gameManager.PauseGame();
        }
    }
    private void OnRemoveItem(InputValue value)
    {

        if (value.isPressed)
        {
            Debug.Log("Remove Item");
            //GetComponent<InventoryScript>().RemoveItem();
        }
    }
}
