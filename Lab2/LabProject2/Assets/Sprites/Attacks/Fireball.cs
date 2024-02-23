using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.position = Vector3.MoveTowards(transform.position, endAt, speed * Time.deltaTime);

            if (transform.position == endAt)
            {
                call(connectedCombatAction);
                active = false;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
