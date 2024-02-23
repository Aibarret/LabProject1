using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Character[] characters = new Character[1];

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
