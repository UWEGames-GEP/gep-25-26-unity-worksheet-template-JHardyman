using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class InventoryScript : MonoBehaviour
{
    public List<ItemScript> items = new List<ItemScript>();

    public GameManagerAdd gameManager;
    public Transform ItemTransform;
    public InventoryScript Inventory;


    public GameObject InventoryPanel;
    public List<GameObject> InventoryUI = new List<GameObject>();

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManagerAdd>();
        Transform ItemTransform = GameObject.Find("Items").transform;

    }


    private void OnEnable()
    {
        InventoryUI.Clear();
        CollectButtons(InventoryPanel.transform, InventoryUI);
        RefreshInventory();
    }
    void Update()
    {
        

    }

    public void AddItemToInventory(ItemScript item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemScript item)
    {

        Vector3 currentPosition = transform.position;
        Vector3 forward = transform.forward;

        Vector3 newPosition = currentPosition + forward;
        newPosition += new Vector3(0, 1, 0);

        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

        GameObject newitem = Instantiate(item.gameObject, newPosition, newRotation, ItemTransform);
        newitem.SetActive(true);

        items.Remove(item);
        Destroy(item.gameObject);


    }

    public void RemoveItemFromInventory()
    {

        if (gameManager.state == GameManagerAdd.GameState.GAMEPLAY && items.Count > 0)
        {

            ItemScript item = items[0];
            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;
            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);
            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);
            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, ItemTransform);
            newItem.SetActive(true);
            RemoveItem(item);
            Destroy(item.gameObject);

        }

    }

    public void RemoveItemFromInventory(int i)
    {
        if (i < items.Count)
        {
            RemoveItem(items[i]);
            RefreshInventory();
        }
    }
    void RefreshInventory()
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
                var uiButtons = InventoryUI[i].GetComponent<InventoryUI>();
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



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemScript collisionItem = hit.gameObject.GetComponent<ItemScript>();


        if (collisionItem != null)
        {
            items.Add(collisionItem);

            collisionItem.gameObject.SetActive(false);
        }

    }
}
