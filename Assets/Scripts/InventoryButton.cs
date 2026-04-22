using TMPro;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public TMP_Text buttontext;

    public void SetButton(ItemScript item)
    {
        buttontext.text = item.itemName;
    }
}
