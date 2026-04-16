using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RefreshInventory : MonoBehaviour
{
    public InventoryScript Inventory;
    public List<GameObject> InventoryUI = new List<GameObject>();
    public GameObject InventoryPannel;


    public void OnInventoryUIButtons(int i)
    {
        Inventory.RemoveItem(i);
        InventoryRefresh();
    }
    private void OnEnable()
    {
        InventoryUI.Clear();
        CollectButtons(InventoryPannel.transform, InventoryUI);
        InventoryRefresh();
    }

    void InventoryRefresh()
    {
        Debug.Log("Refresh Inventory UI");

        foreach (GameObject button in InventoryUI)
        {
            button.SetActive(false);
        }

        Debug.Log(Inventory.items.Count);
        for (int i = 0; i < Inventory.items.Count; i++)
        {
            Debug.Log(InventoryUI.Count);

            if (i < InventoryUI.Count)
            {
                var uiButtons = InventoryUI[i].GetComponent<InventoryUIButtons>();
                var item = Inventory.items[i];

                uiButtons.gameObject.SetActive(true);
                uiButtons.SetButton(item);

            }

        }

    }

    public void CollectButtons(Transform pannel, List<GameObject> list)
    {
        foreach (Transform button in pannel)
        {
            if (button.gameObject.tag == "Button")
            {
                list.Add(button.gameObject);
            }
        }


    }







}
