using TMPro;
using UnityEngine;

public class InventoryUIButtons : MonoBehaviour
{

    public TMP_Text buttontext;

    public void SetButton(ItemScript item)
    {
        buttontext.text = item.itemName;
    }

}
