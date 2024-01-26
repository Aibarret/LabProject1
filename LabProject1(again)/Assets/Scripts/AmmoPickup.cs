using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour, IPickUpable, InventoryItem
{
    [SerializeField] private int ammo;
    private PlaterCont player;

    public void Activate()
    {
        player.PickUpAmmo(ammo);
    }

    public void PickUp(PlaterCont player)
    {
        this.player = player;
        player.AddToInventory(this);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUp(other.gameObject.GetComponent<PlaterCont>());

            
        }
    }

}
