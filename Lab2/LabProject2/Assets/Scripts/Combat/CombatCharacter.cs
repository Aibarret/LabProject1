using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    public bool isPlayer;
    public List<CombatActions> combatActions;

    public int curHp;
    public int maxHP;

    [SerializeField] private CombatCharacter opponent;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;

    }

    public void TakeDamage(int damageToTake)
    {
        curHp -= damageToTake;

        CombatEvents.instance.e_onHealthChange.Invoke();

        if (curHp <= 0)
        {
            die();
        }
    }


    public void die()
    {
        CombatEvents.instance.e_onCharacterDie.Invoke(this);
        Destroy(gameObject);
    }

    public void Heal(int healAmount)
    {
        curHp += healAmount;

        CombatEvents.instance.e_onHealthChange.Invoke();

        if (curHp > maxHP)
        {
            curHp = maxHP;
        }
    }

    public void CastCombatAction(CombatActions combatAction)
    {
        if (combatAction.ProjectilePrefab != null)
        {
            GameObject proj = Instantiate(combatAction.ProjectilePrefab, transform.position, Quaternion.identity);
            proj.GetComponent<Projectile>().startAnimation(transform.position, opponent.transform.position, combatAction, onProjectileComplete);

        }
        else if (combatAction.Damage > 0)
        {
            StartCoroutine(AttackOpponent(combatAction));
        }
        else if (combatAction.HealAmount > 0)
        {
            Heal(combatAction.HealAmount);
            TurnManager.instance.EndTurn();
        }
        else
        {
            TurnManager.instance.EndTurn();
        }
    }

    IEnumerator AttackOpponent(CombatActions combatAction)
    {
        while (transform.position != opponent.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, opponent.transform.position, 50 * Time.deltaTime);
            yield return null;
        }

        opponent.TakeDamage(combatAction.Damage);

        while (transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 20 * Time.deltaTime);
            yield return null;
        }

        TurnManager.instance.EndTurn();
    }

    public float getHealthPercentage()
    {
        return (float)(curHp / maxHP);
    }

    public void onProjectileComplete(CombatActions completedAction)
    {
        opponent.TakeDamage(completedAction.Damage);
        TurnManager.instance.EndTurn();
    }
}
