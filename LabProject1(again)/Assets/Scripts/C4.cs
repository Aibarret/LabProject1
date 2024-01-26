using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour, InventoryItem, IPickUpable
{
    public float radius = 5f;
    public float power = 25;

    [SerializeField] ParticleSystem explosrion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Player Entered");
            PickUp(other.gameObject.GetComponent<PlaterCont>());
        }
    }

    public void TriggerC4()
    {
        Vector3 explodePosn = transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(explodePosn, radius);
        explosrion.Play();
        foreach(Collider thing in hitColliders)
        {
            if (thing.attachedRigidbody != null)
            {
                thing.attachedRigidbody.AddExplosionForce(power, explodePosn, radius, 0.0f, ForceMode.Impulse);
            }
        }
    }

    public void PickUp(PlaterCont player)
    {
        player.AddToInventory(this);
    }

    public void Activate()
    {
        TriggerC4();
    }
}
