using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventoryScript Inventory;
    public GameObject InventoryPanel;
    public List<GameObject> InventoryButton = new List<GameObject>();

    private void OnEnable()
    {
        InventoryButton.Clear();
        CollectButtons(InventoryPanel.transform, InventoryButton);
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        Debug.Log("Refresh Inventory UI");

        foreach (GameObject button in InventoryButton)
        {
            button.SetActive(false);
        }

        Debug.Log(Inventory.items.Count);
        for (int i = 0; i < Inventory.items.Count; i++)
        {
            Debug.Log(InventoryButton.Count);

            if (i < InventoryButton.Count)
            {
                var uiButtons = InventoryButton[i].GetComponent<InventoryButton>();
                var item = Inventory.items[i];

                uiButtons.gameObject.SetActive(true);
                uiButtons.SetButton(item);

            }

        }
    }
    public void CollectButtons(Transform panel, List<GameObject> list)
    {
        foreach (Transform button in panel)
        {
            if (button.gameObject.tag == "Button")
            {
                list.Add(button.gameObject);
            }
        }


    }

    public void OnInventoryUIButton(int i)
    {
        Inventory.RemoveItemFromInventory(i);
        RefreshInventory();
    }
}
