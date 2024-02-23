using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreator : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI displayText;
    public TMP_Dropdown dropdown;

    private Character currentCharacter;
    private List<int> stats = new List<int>();
    private Character.AbilityScores abilityScores;
    

    [SerializeField] private Enums.CharacterClass cClass;

    private void Start()
    {
        rollStats();
    }

    public void rollStats()
    {
        print("rollingStats");
        string text = "";
        stats = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            stats.Add(Random.Range(1, 13));
        }
       
        abilityScores = new Character.AbilityScores();

        abilityScores.strength = stats[0];
        abilityScores.charisma = stats[1];
        abilityScores.constitution = stats[2];
        abilityScores.dexterity = stats[3];
        abilityScores.wisdom = stats[4];
        abilityScores.intelligence = stats[5];


        text += "Strength: " + abilityScores.strength + "\n";
        text += "Constitution: " + abilityScores.constitution + "\n";
        text += "Dexterity: " + abilityScores.dexterity + "\n";
        text += "Intelligence: " + abilityScores.intelligence + "\n";
        text += "Wisdom: " + abilityScores.wisdom + "\n";
        text += "Charisma: " + abilityScores.charisma + "\n";

        displayText.text = text;

    }

    public void setClass()
    {
        cClass = (Enums.CharacterClass) dropdown.value;
        print(cClass);
    }

    public void createCharacter()
    {
        GameManager.characters[0] = new Character(nameInput.text, null, cClass, Enums.CharacterType.Human, abilityScores);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Overworld");
    }


}
