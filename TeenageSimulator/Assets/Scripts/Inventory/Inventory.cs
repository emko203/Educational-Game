using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.Log("More than once instance of Inventory exists");
        }
        instance = this;
    }

    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //Inventory Space
    public int space = 3;

    public List<Item> items = new List<Item>();

    public bool Add(Item item) 
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory is full");
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback !=null)
            {
                onItemChangedCallback.Invoke();
            }           
        }
        return true;
    }

    public void Remove(Item item) 
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
