using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodoTutorial : MonoBehaviour
{
    public GameObject ObservacionTitulo;
    public GameObject PreguntasTitulo;
    public GameObject HipotesisTitulo;

    public GameObject ObservacionText;
    public GameObject PreguntasText;
    public GameObject HipotesisText;
    public GameObject ComentarioText;

    public GameObject Respuesta1;
    public GameObject Respuesta2;
    public GameObject Respuesta3;
    public GameObject Respuesta4;

    public GameObject RespuestaButton1;
    public GameObject RespuestaButton2;
    public GameObject RespuestaButton3;
    public GameObject RespuestaButton4;

    public GameObject ObservacionButton;
    public GameObject PreguntasButton;
    public GameObject SiguienteButton;
    public GameObject PasarNivel;

    public int RespuestaCorrecta;


    // Start is called before the first frame update
    public void ObservacionClick()
    {
        ObservacionTitulo.SetActive(false);
        ObservacionText.SetActive(false);
        ObservacionButton.SetActive(false);

        PreguntasButton.SetActive(true);
        PreguntasTitulo.SetActive(true);
        PreguntasText.SetActive(true);
    }


    public void PreguntasClick()
    {
        PreguntasTitulo.SetActive(false);
        PreguntasText.SetActive(false);
        Respuesta1.SetActive(false);
        Respuesta2.SetActive(false);
        Respuesta3.SetActive(false);
        Respuesta4.SetActive(false);
        PreguntasButton.SetActive(false);

        HipotesisTitulo.SetActive(true);
        HipotesisText.SetActive(true);
        RespuestaButton1.SetActive(true);
        RespuestaButton2.SetActive(true);
        RespuestaButton3.SetActive(true);
        RespuestaButton4.SetActive(true);
        SiguienteButton.SetActive(false);
        PasarNivel.SetActive(false);
    }
    public void Respuesta1Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        HipotesisText.SetActive(false);
        Respuesta1.SetActive(true);
        int n = 1;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else {
            PreguntasButton.SetActive(true);
        }
    }
    public void Respuesta2Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        HipotesisText.SetActive(false);
        Respuesta2.SetActive(true);
        int n = 2;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else
        {
            PreguntasButton.SetActive(true);
        }
    }
    public void Respuesta3Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        HipotesisText.SetActive(false);
        Respuesta3.SetActive(true);
        int n = 3;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else
        {
            PreguntasButton.SetActive(true);
        }
    }

    public void Respuesta4Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        HipotesisText.SetActive(false);
        Respuesta4.SetActive(true);
        int n = 4;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else
        {
            PreguntasButton.SetActive(true);
        }
    }
    public void SiguienteClick()
    {
        Respuesta1.SetActive(false);
        Respuesta2.SetActive(false);
        Respuesta3.SetActive(false);
        Respuesta4.SetActive(false);

        ComentarioText.SetActive(true);
        SiguienteButton.SetActive(false);
        PasarNivel.SetActive(true);
    }

    public void PasarNivelClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
