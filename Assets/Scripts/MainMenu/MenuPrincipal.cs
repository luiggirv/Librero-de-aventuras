using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject principalUI;
    public GameObject seleccionarUI;

    public void Siguiente()
    {
        principalUI.SetActive(false);
        seleccionarUI.SetActive(true);
    }

    public void Ecosistema()
    {
        SceneManager.LoadScene(1);
    }

    public void Sistema()
    {
        SceneManager.LoadScene(4);
    }

    public void Metodo()
    {
        SceneManager.LoadScene(19);
    }

    public void Regresar()
    {
        seleccionarUI.SetActive(false);
        principalUI.SetActive(true);
    }
}
