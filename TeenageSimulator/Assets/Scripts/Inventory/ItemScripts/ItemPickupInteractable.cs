using UnityEngine;

public class ItemPickupInteractable : Interactable
{
    public Item item;

    public override void HandleInteraction(Transform player)
    {
        PickUp();
    }


    public void PickUp() 
    {
        Debug.Log("Picking up " + item.name);
        //Add to inventory
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }        
    }
}
