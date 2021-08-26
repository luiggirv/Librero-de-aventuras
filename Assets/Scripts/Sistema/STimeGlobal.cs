using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class STimeGlobal : MonoBehaviour
{
    public float timeStart;
    public GameObject TiempoReal;
    public static bool GameIsPause = false;
    public  GameObject finNivelUI;
    public GameObject puntajeNivelFinal;
    public GameObject puntajeTotal;

    void Start()
    {
        GameIsPause = false;
        TiempoReal.GetComponent<Text>().text = timeStart.ToString() + " segundos";
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        TiempoReal.GetComponent<Text>().text = Mathf.Round(timeStart).ToString() + " segundos";

        if (Mathf.Round(timeStart) == 0)
        {
            var clones = GameObject.FindGameObjectsWithTag("Virus");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            var clonesObjetos = GameObject.FindGameObjectsWithTag("Objeto");
            foreach (var clone in clonesObjetos)
            {
                Destroy(clone);
            }
            puntajeNivelFinal.GetComponent<Text>().text = "Puntaje total: " + puntajeTotal.GetComponent<Text>().text;
            finNivelUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;            
        }
    }

    public void ContinuarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(8);
        timeStart = 999;
        if (LevelSelect.lvl1Entrar == true)
        {
            LevelSelect.lvl1Superado = true;
        }
        else if (LevelSelect.lvl2Entrar == true)
        {
            LevelSelect.lvl2Superado = true;
        }
        else if (LevelSelect.lvl3Entrar == true)
        {
            LevelSelect.lvl3Superado = true;
        }
        else if (LevelSelect.lvl4Entrar == true)
        {
            LevelSelect.lvl4Superado = true;
        }
        else if (LevelSelect.lvl5Entrar == true)
        {
            LevelSelect.lvl5Superado = true;
        }
        else if (LevelSelect.lvl6Entrar == true)
        {
            LevelSelect.lvl6Superado = true;
        }
    }

    public void RegresarMenu()
    {
        timeStart = 999;
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }

}
