using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] CombatCharacter character;
    [SerializeField] TMPro.TMP_Text healthText;
    [SerializeField] Slider healthSldier;

    // Start is called before the first frame update
    void Start()
    {
        CombatEvents.instance.e_onHealthChange.AddListener(onHealthUpdate);
        healthSldier.maxValue = character.maxHP;
        healthSldier.value = character.curHp;
        healthText.text = character.curHp + " / " + character.maxHP;
    }

    public void onHealthUpdate()
    {
        healthText.text = character.curHp + " / " + character.maxHP;
        healthSldier.value = character.curHp;
    }
}
