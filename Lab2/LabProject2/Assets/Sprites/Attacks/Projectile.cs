using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public delegate void ReturnCall(CombatActions ca);

    public float speed;

    [HideInInspector] public ReturnCall call;
    [HideInInspector] public Vector3 startFrom;
    [HideInInspector] public Vector3 endAt;
    [HideInInspector] public CombatActions connectedCombatAction;
    [HideInInspector] public bool active = false;

    public virtual void startAnimation(Vector3 start, Vector3 end, CombatActions combatAction, ReturnCall callTo)
    {
        call += callTo;
        startFrom = start;
        endAt = end;
        connectedCombatAction = combatAction;

        active = true;
    }
}
