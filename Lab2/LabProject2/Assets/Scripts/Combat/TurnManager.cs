using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private CombatCharacter[] characters;
    [SerializeField] private float nextTurnDelay = 1.0f;

    private int curCharacterIndex = -1;
    public CombatCharacter currentCharacter;

    public static TurnManager instance;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        onBeginTurn();
    }


    public void onBeginTurn()
    {
        curCharacterIndex++;

        if (curCharacterIndex >= characters.Length)
        {
            curCharacterIndex = 0;
        }

        currentCharacter = characters[curCharacterIndex];
        CombatEvents.instance.e_onBeginTurn.Invoke(currentCharacter);
    }

    public void EndTurn()
    {
        CombatEvents.instance.e_onEndTurn.Invoke(currentCharacter);

        Invoke(nameof(onBeginTurn), nextTurnDelay);
    }

    private void onCharacterDie(CombatCharacter characater)
    {

    }
}
