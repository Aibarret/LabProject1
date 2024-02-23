using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
    }

    public void newGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterCreation");
    }
}
