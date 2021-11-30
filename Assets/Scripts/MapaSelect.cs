using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapaSelect : MonoBehaviour
{
    public static bool BosqueEntrar;
    public static bool LagoEntrar;
    public static bool MontanaEntrar;

    public GameObject BosqueObject;
    public GameObject LagoObject;
    public GameObject MontanaObject;

    bool tutorialONEcosistema = false;
    private void Start()
    {
        Application.targetFrameRate = 60;

        if (PlayerPrefs.GetInt("TutorialEcosistemas") == 1)
        {
            tutorialONEcosistema = true;
        }
        else
        {
            tutorialONEcosistema = false;
        }

        if (PlayerPrefs.GetInt("isBosque") == 1)
        {
            BosqueObject.GetComponent<Button>().interactable = true;
        }
        else 
        {
            BosqueObject.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.GetInt("isLago") == 1)
        {
            LagoObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            LagoObject.GetComponent<Button>().interactable = false;
        }

        if (PlayerPrefs.GetInt("isMontaña") == 1)
        {
            MontanaObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            MontanaObject.GetComponent<Button>().interactable = false;
        }
    }
    public void Bosque()
    {
        BosqueEntrar = true;
        LagoEntrar = false;
        MontanaEntrar = false;
        if (tutorialONEcosistema)
        {
            LevelSelectEcosistema.lvlTutorialForest = true;
            SceneManager.LoadScene(48);
        }
        else
        {
            SceneManager.LoadScene(15);
        }
    }
    
    public void Lago()
    {
        BosqueEntrar = false;
        LagoEntrar = true;
        MontanaEntrar = false;
        if (tutorialONEcosistema)
        {
            LevelSelectEcosistema.lvlTutorialLake = true;
            SceneManager.LoadScene(54);
        }
        else
        {
            SceneManager.LoadScene(14);
        }
    }

    public void Montaña()
    {
        BosqueEntrar = false;
        LagoEntrar = false;
        MontanaEntrar = true;
        if (tutorialONEcosistema)
        {
            LevelSelectEcosistema.lvlTutorialMountain = true;
            SceneManager.LoadScene(61);
        }
        else
        {
            SceneManager.LoadScene(13);
        }
    }
    public void Regresar()
    {
        BosqueEntrar = false;
        LagoEntrar = false;
        MontanaEntrar = false;
        SceneManager.LoadScene(1);
    }
}
