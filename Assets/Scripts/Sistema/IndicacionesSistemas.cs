using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicacionesSistemas : MonoBehaviour
{
    public GameObject indicacionesUI;
    public static bool GameIsPause = false;
    void Start()
    {
        indicacionesUI.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        GameIsPause = true;

    }

    public void closeIndicacion()
    {
        indicacionesUI.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        GameIsPause = false;
    }
}
