using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaSelect : MonoBehaviour
{
    public static bool BosqueEntrar;
    public static bool LagoEntrar;
    public static bool MontanaEntrar;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void Bosque()
    {
        BosqueEntrar = true;
        LagoEntrar = false;
        MontanaEntrar = false;
        SceneManager.LoadScene(15);
    }
    
    public void Lago()
    {
        BosqueEntrar = false;
        LagoEntrar = true;
        MontanaEntrar = false;
        SceneManager.LoadScene(14);
    }

    public void Montaña()
    {
        BosqueEntrar = false;
        LagoEntrar = false;
        MontanaEntrar = true;
        SceneManager.LoadScene(13);
    }
    public void Regresar()
    {
        BosqueEntrar = false;
        LagoEntrar = false;
        MontanaEntrar = false;
        SceneManager.LoadScene(1);
    }
}
