using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] CombatCharacter character;
    public AnimationCurve healRate;

    private void Start()
    {
        CombatEvents.instance.e_onBeginTurn.AddListener(onBeginTurn);
    }

    public void onBeginTurn(CombatCharacter charac)
    {
        if (character == charac)
        {
            DetermineCombatAction();
        }
    }

    public void DetermineCombatAction()
    {
        float healthPercentage = character.getHealthPercentage();

        bool wantToHeal = Random.value < healRate.Evaluate(healthPercentage);

        CombatActions ca = null;

        if (wantToHeal && DetermineIfHasCombatAction(Enums.AttackType.Heal))
        {
            ca = GetCombatActionOfType(Enums.AttackType.Heal);
        }
        else if (DetermineIfHasCombatAction(Enums.AttackType.Attack))
        {
            ca = GetCombatActionOfType(Enums.AttackType.Attack);
        }

        if (ca != null)
        {
            character.CastCombatAction(ca);
        }
        else
        {
            TurnManager.instance.EndTurn();
        }
    }

    private bool DetermineIfHasCombatAction(Enums.AttackType action)
    {
        return character.combatActions.Exists(x => x.ActionType == action);
    }

    private CombatActions GetCombatActionOfType(Enums.AttackType action)
    {
        List<CombatActions> availableActions = character.combatActions.FindAll(x => x.ActionType == action);

        return availableActions[Random.Range(0, availableActions.Count)];
    }
}
