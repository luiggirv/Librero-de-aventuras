using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodoMainMenu : MonoBehaviour
{
    bool tutorialONMetodo = false;
    private void Start()
    {
        if (PlayerPrefs.GetInt("TutorialMetodo") == 1) 
        {
            tutorialONMetodo = true;
        }
        else
        {
            tutorialONMetodo = false;
        }
    }
    public void Continuar()
    {
        if (tutorialONMetodo)
        {
            SceneManager.LoadScene(77);
        }
        else
        {
            SceneManager.LoadScene(20);
        }
    }

    public void Regresar()
    {
        SceneManager.LoadScene(80);
    }
}
