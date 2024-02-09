using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character
{
    struct AbilityScores
    {
        public int strength;
        public int dexterity;
        public int constitution;
        public int intelligence;
        public int wisdom;
        public int charisma;

    }

    public string name;

    private Enums.CharacterClass cClass;
    private Enums.CharacterType type;
    private Enums.AbilityScoreNames abilityScoreName;
    private AbilityScores stats;

    private GameObject playerPrefab;

    Character(string name, GameObject player, Enums.CharacterClass cClass, Enums.CharacterType type, Enums.AbilityScoreNames abilityScoreName)
    {
        this.name = name;
        playerPrefab = player;
        this.cClass = cClass;
        this.type = type;
        this.abilityScoreName = abilityScoreName;

        stats = new AbilityScores();
    }

    public int GetAbilityScoreBonus(Enums.AbilityScoreNames abilityName)
    {
        switch (abilityName)
        {
            case Enums.AbilityScoreNames.strength:
                return stats.strength;
            case Enums.AbilityScoreNames.dexterity:
                return stats.dexterity;
            case Enums.AbilityScoreNames.constitution:
                return stats.constitution;
            case Enums.AbilityScoreNames.intelligence:
                return stats.intelligence;
            case Enums.AbilityScoreNames.wisdom:
                return stats.wisdom;
            case Enums.AbilityScoreNames.charisma:
                return stats.charisma;
            default:
                return 0;
        }
    }


}
