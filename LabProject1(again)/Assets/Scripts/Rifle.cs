using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public ParticleSystem particleSystem;

    public override void Shoot()
    {
        base.Shoot();
        particleSystem.Play();
    }

}
