using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodoTutorial : MonoBehaviour
{

    public GameObject[] listaDeObjetos;
    int i;

    public void Start()
    {
        i = 0;
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

    public void PasarNivelClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void VolverMenuClick()
    {
        SceneManager.LoadScene(20);
    }
}
