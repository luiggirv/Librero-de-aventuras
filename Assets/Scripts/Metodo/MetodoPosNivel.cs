using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetodoPosNivel : MonoBehaviour
{
    public GameObject ResultadoTitulo;
    public GameObject ConclusionesTitulo;

    public GameObject ResultadoText;
    public GameObject ConclusionText;
    public GameObject ComentarioFinalText;
    public GameObject FinalText;

    public GameObject Respuesta1;
    public GameObject Respuesta2;
    public GameObject Respuesta3;
    public GameObject Respuesta4;

    public GameObject RespuestaButton1;
    public GameObject RespuestaButton2;
    public GameObject RespuestaButton3;
    public GameObject RespuestaButton4;

    public GameObject ResultadoButton;
    public GameObject ConclusionButton;
    public GameObject SiguienteButton;
    public GameObject PasarNivel;

    public int RespuestaCorrecta;


    // Start is called before the first frame update
    public void ResultadoClick()
    {
        ResultadoTitulo.SetActive(false);
        ResultadoText.SetActive(false);
        ResultadoButton.SetActive(false);

        ConclusionesTitulo.SetActive(true);
        ConclusionText.SetActive(true);
        ConclusionButton.SetActive(true);
    }


    public void ComentarioClick()
    {
        ConclusionText.SetActive(false);
        ConclusionButton.SetActive(false);
        Respuesta1.SetActive(false);
        Respuesta2.SetActive(false);
        Respuesta3.SetActive(false);
        Respuesta4.SetActive(false);

        ComentarioFinalText.SetActive(true);
        RespuestaButton1.SetActive(true);
        RespuestaButton2.SetActive(true);
        RespuestaButton3.SetActive(true);
        RespuestaButton4.SetActive(true);
        SiguienteButton.SetActive(false);
    }
    public void Respuesta1Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        ComentarioFinalText.SetActive(false);
        Respuesta1.SetActive(true);
        int n = 1;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else {
            ConclusionButton.SetActive(true);
        }
    }
    public void Respuesta2Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        ComentarioFinalText.SetActive(false);
        Respuesta2.SetActive(true);
        int n = 2;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else
        {
            ConclusionButton.SetActive(true);
        }
    }
    public void Respuesta3Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        ComentarioFinalText.SetActive(false);
        Respuesta3.SetActive(true);
        int n = 3;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else
        {
            ConclusionButton.SetActive(true);
        }
    }

    public void Respuesta4Click()
    {
        RespuestaButton1.SetActive(false);
        RespuestaButton2.SetActive(false);
        RespuestaButton3.SetActive(false);
        RespuestaButton4.SetActive(false);
        ComentarioFinalText.SetActive(false);
        Respuesta4.SetActive(true);
        int n = 4;
        if (n == RespuestaCorrecta)
        {
            SiguienteButton.SetActive(true);
        }
        else
        {
            ConclusionButton.SetActive(true);
        }
    }
    public void SiguienteClick()
    {
        Respuesta1.SetActive(false);
        Respuesta2.SetActive(false);
        Respuesta3.SetActive(false);
        Respuesta4.SetActive(false);

        FinalText.SetActive(true);
        SiguienteButton.SetActive(false);
        PasarNivel.SetActive(true);
    }

    public void PasarClick()
    {
        SceneManager.LoadScene(20);
    }

}
