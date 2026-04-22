using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class InventoryScript : MonoBehaviour
{
    public List<ItemScript> items = new List<ItemScript>();

    public GameManagerAdd gameManager;
    public Transform ItemTransform;
    public InventoryScript Inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Find The Game Manager and reference it
        gameManager = FindAnyObjectByType<GameManagerAdd>();

        //Find Items transform and reference it
        Transform ItemTransform = GameObject.Find("Items").transform;

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //    AddItem("Generic Item");
        // }
        // if (Input.GetKeyDown(KeyCode.Y))
        // {
        //    RemoveItem("Generic Item");
        //  }

    }

    public void AddItem(ItemScript item)
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

    public void RemoveItem()
    {

        if (gameManager.state == GameManagerAdd.GameState.GAMEPLAY && items.Count > 0)
        {

            ItemScript item = items[0];

            RemoveItem(item);

            // ItemScript item = items[0];
            //Vector3 currentPosition = transform.position;
            // Vector3 forward = transform.forward;
            // Vector3 newPosition = currentPosition + forward;
            // newPosition += new Vector3(0, 1, 0);
            // Quaternion currentRotation = transform.rotation;
            // Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);
            // GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, ItemTransform);
            // newItem.SetActive(true);
            // items.Remove(item);
            // Destroy(item.gameObject);

        }

    }

    public void RemoveItem(int i)
    {
        if (i < items.Count)
        {
            RemoveItem(items[i]);
        }
    }





    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemScript collisionItem = hit.gameObject.GetComponent<ItemScript>();


        if (collisionItem != null)
        {
            items.Add(collisionItem);

            Destroy(collisionItem.gameObject);

            collisionItem.gameObject.SetActive(false);
        }

    }
}
