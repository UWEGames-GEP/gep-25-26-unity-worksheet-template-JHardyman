using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        //Debug.Log(InventoryButton.Count);

        foreach (GameObject button in InventoryButton)
        {
            button.SetActive(false);
        }

        Debug.Log("Items: " + Inventory.items.Count);
        for (int i = 0; i < Inventory.items.Count; i++)
        {
            Debug.Log("Buttons: " + InventoryButton.Count);

            if (i < InventoryButton.Count)
            {
                var uiButton = InventoryButton[i].GetComponent<InventoryButton>();
                var item = Inventory.items[i];

                uiButton.gameObject.SetActive(true);
                uiButton.SetButton(item);

                Button btn = InventoryButton[i].GetComponent<Button>();
                int index = i;
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => OnInventoryUIButton(index));
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
