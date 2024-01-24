using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4 : MonoBehaviour
{
    public float radius = 5f;
    public float power = 25;

    [SerializeField] ParticleSystem explosrion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
