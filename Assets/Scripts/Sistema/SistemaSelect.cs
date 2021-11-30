using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SistemaSelect : MonoBehaviour
{
    public static bool SistemaRespiratorioEntrar;
    public static bool SistemaNerviosoEntrar;
    public static bool SistemaCirculatorioEntrar;
    bool tutorialONSistema = false;

    public GameObject respiratorioObject;
    public GameObject circulatorioObject;
    public GameObject nerviosoObject;
    void Start()
    {
        Application.targetFrameRate = 60;

        if (PlayerPrefs.GetInt("TutorialSistemas") == 1)
        {
            tutorialONSistema = true;
        }
        else
        {
            tutorialONSistema = false;
        }

        if (PlayerPrefs.GetInt("isRespiratorio") == 1)
        {
            respiratorioObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            respiratorioObject.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.GetInt("isNervioso") == 1)
        {
            nerviosoObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            nerviosoObject.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.GetInt("isCirculatorio") == 1)
        {
            circulatorioObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            circulatorioObject.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    public void Respiratorio()
    {
        SistemaRespiratorioEntrar = true;
        SistemaNerviosoEntrar = false;
        SistemaCirculatorioEntrar = false;
        if (tutorialONSistema)
        {
            LevelSelect.lvlTutorialRespiratorio = true;
            SceneManager.LoadScene(40);
        }
        else
        {
            SceneManager.LoadScene(8);
        }
    }
    public void Circulatorio()
    {
        SistemaCirculatorioEntrar = true;
        SistemaRespiratorioEntrar = false;
        SistemaNerviosoEntrar = false;
        if (tutorialONSistema)
        {
            LevelSelect.lvlTutorialCirculatorio = true;
            SceneManager.LoadScene(32);
        }
        else
        {
            SceneManager.LoadScene(26);
        }
    }
    public void Nervioso()
    {
        SistemaNerviosoEntrar = true;
        SistemaRespiratorioEntrar = false;
        SistemaCirculatorioEntrar = false;
        if (tutorialONSistema)
        {
            LevelSelect.lvlTutorialNervioso = true;
            SceneManager.LoadScene(41);
        }
        else
        {
            SceneManager.LoadScene(33);
        }

    }
    public void Regresar()
    {
        SistemaCirculatorioEntrar = false;
        SistemaRespiratorioEntrar = false;
        SistemaNerviosoEntrar = false;
        SceneManager.LoadScene(4);
    }
}
