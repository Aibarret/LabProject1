using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatActionsUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject visualContainer;
    [SerializeField] private Button[] combatActionButtons;

    private void Start()
    {
        CombatEvents.instance.e_onBeginTurn.AddListener(onBeginTurn);
        CombatEvents.instance.e_onEndTurn.AddListener(onEndTurn);
    }

    public void onBeginTurn(CombatCharacter character)
    {
        if (!character.isPlayer)
        {
            return;
        }

        visualContainer.SetActive(true);

        for (int i = 0; i < combatActionButtons.Length; i++)
        {
            if (i < character.combatActions.Count)
            {
                combatActionButtons[i].gameObject.SetActive(true);
                CombatActions ca = character.combatActions[i];

                combatActionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = ca.DisplayName;
                combatActionButtons[i].onClick.RemoveAllListeners();
                combatActionButtons[i].onClick.AddListener(() => OnClickCombatAction(ca));
            }
            else
            {
                combatActionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void onEndTurn(CombatCharacter character)
    {
        visualContainer.gameObject.SetActive(false);
    }

    public void OnClickCombatAction(CombatActions combatAction)
    {
        TurnManager.instance.currentCharacter.CastCombatAction(combatAction);
    }
}
