using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerCharacterController : ThirdPersonController
{
    public GameManagerAdd GameManager;

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Pause");
            GameManager.PauseGame();
        }
    }
    private void OnRemoveItem(InputValue value)
    {

        if (value.isPressed)
        {
            Debug.Log("Remove Item");
            GetComponent<InventoryScript>().RemoveItemFromInventory();
        }
    }


}
