using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour, IPickUpable
{
    [SerializeField] private int ammo;
    public void PickUp(PlaterCont player)
    {
        player.PickUpAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUp(other.gameObject.GetComponent<PlaterCont>());

            GameObject.Destroy(gameObject);
        }
    }

}
