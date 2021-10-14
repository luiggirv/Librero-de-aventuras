using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodoMainMenu : MonoBehaviour
{
    public void Continuar()
    {
        SceneManager.LoadScene(20);
    }

    public void Regresar()
    {
        SceneManager.LoadScene(80);
    }
}
