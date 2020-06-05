using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public GameObject inventoryUI;
    bool active;
    public void OpenCloseInventory()
    {
        if (inventoryUI != null && active == false)
        {
            inventoryUI.SetActive(true);
            active = true;
        }
        else
        {
            inventoryUI.SetActive(false);
            active = false;
        }
    }

    

}
