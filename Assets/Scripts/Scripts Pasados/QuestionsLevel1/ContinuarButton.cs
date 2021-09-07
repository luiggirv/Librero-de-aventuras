using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuarButton : MonoBehaviour
{
    public GameObject principalUI;
    public GameObject pregunta1UI;
    void Update()
    {
        
    }

    public void SigPregunta()
    {
        principalUI.SetActive(false);
        pregunta1UI.SetActive(true);
    }

    public void Regresar()
    {
        SceneManager.LoadScene(0);
    }
}
