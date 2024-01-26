using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string gunName;
    [SerializeField] protected int currentBullets;
    [SerializeField] protected int maxBullets;
    

    [SerializeField] protected GameObject bulletHole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shoot()
    {
        if (currentBullets > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                GameObject decal = Instantiate(bulletHole, hit.point, Quaternion.identity);
                decal.transform.forward = -hit.normal;
                decal.transform.Translate(Vector3.back * 0.01f);

                Vector3 worldPosition = decal.transform.position;
                Quaternion worldRotation = decal.transform.rotation;
                decal.transform.SetParent(hit.transform);
                decal.transform.position = worldPosition;
                decal.transform.rotation = worldRotation;

                
            }

            currentBullets--;
        }

        print("Shot Gun bullets at " + currentBullets);
    }

    public virtual int Reload(int rounds)
    {
        if (currentBullets < maxBullets)
        {
            currentBullets += rounds;
            int roundsLeft = currentBullets - maxBullets; 

            if (currentBullets > maxBullets)
            {
                currentBullets = maxBullets;
            }

            if (roundsLeft < 0)
            {
                roundsLeft = 0;
            }

            return roundsLeft;
        }

        return rounds;
    }
}
