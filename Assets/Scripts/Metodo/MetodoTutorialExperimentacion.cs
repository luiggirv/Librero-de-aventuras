using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodoTutorialExperimentacion : MonoBehaviour
{

    public GameObject[] listaDeObjetos;
    int i;
    public GameObject instructionsUI;
    public static bool GameIsPause = false;

    void Start()
    {
        i = 0;
        instructionsUI.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        GameIsPause = true;
    }


    // Start is called before the first frame update
    public void AnteriorClick()
    {
        if (i <= 0)
        {
            return;
        }
        else
        {
            listaDeObjetos[i].SetActive(false);
            listaDeObjetos[i - 1].SetActive(true);
            i--;
        }
        Debug.Log("Anterior");
    }
    public void SiguienteClick()
    {
        if (i >= listaDeObjetos.Length-1)
        {
            return;
        }
        else
        {
            listaDeObjetos[i].SetActive(false);
            listaDeObjetos[i + 1].SetActive(true);
            i++;
        }
        Debug.Log("Siguiente");
    }

    public void closeIndicacion()
    {
        instructionsUI.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        GameIsPause = false;
    }

}
