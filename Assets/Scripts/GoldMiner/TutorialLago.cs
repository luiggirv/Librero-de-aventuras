using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLago : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject tutorialUI;
    public GameObject paso1;
    public GameObject paso2;
    public GameObject paso3;
    public GameObject paso4;

    void Start()
    {
        AudioListener.pause = true;
        tutorialUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void SiguientePaso2()
    {
        paso1.SetActive(false);
        paso2.SetActive(true);
    }

    public void AnteriorPaso2()
    {
        paso2.SetActive(false);
        paso1.SetActive(true);
    }
    public void SiguientePaso3()
    {
        paso2.SetActive(false);
        paso3.SetActive(true);
    }

    public void AnteriorPaso3()
    {
        paso3.SetActive(false);
        paso2.SetActive(true);
    }
    public void SiguientePaso4()
    {
        paso3.SetActive(false);
        paso4.SetActive(true);
    }

    public void AnteriorPaso4()
    {
        paso4.SetActive(false);
        paso3.SetActive(true);
    }

    public void Continuar()
    {
        AudioListener.pause = false;
        tutorialUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

}
