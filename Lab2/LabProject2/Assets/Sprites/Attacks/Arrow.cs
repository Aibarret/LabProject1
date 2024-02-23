using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile
{
    private float elaspedframes = 0f;

  
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.position = Vector3.Slerp(startFrom, endAt, elaspedframes / speed);

            elaspedframes += Time.deltaTime;

            if (elaspedframes >= speed)
            {
                call(connectedCombatAction);
                active = false;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
