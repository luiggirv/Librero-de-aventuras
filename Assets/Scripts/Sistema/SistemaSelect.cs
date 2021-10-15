using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaSelect : MonoBehaviour
{
    public static bool SistemaRespiratorioEntrar;
    public static bool SistemaNerviosoEntrar;
    public static bool SistemaCirculatorioEntrar;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    public void Respiratorio()
    {
        SistemaRespiratorioEntrar = true;
        SistemaNerviosoEntrar = false;
        SistemaCirculatorioEntrar = false;
        SceneManager.LoadScene(8);
    }
    public void Circulatorio()
    {
        SistemaCirculatorioEntrar = true;
        SistemaRespiratorioEntrar = false;
        SistemaNerviosoEntrar = false;
        SceneManager.LoadScene(26);
    }
    public void Nervioso()
    {
        SistemaNerviosoEntrar = true;
        SistemaRespiratorioEntrar = false;
        SistemaCirculatorioEntrar = false;
        SceneManager.LoadScene(33);
    }
    public void Regresar()
    {
        SistemaCirculatorioEntrar = false;
        SistemaRespiratorioEntrar = false;
        SistemaNerviosoEntrar = false;
        SceneManager.LoadScene(4);
    }
}
