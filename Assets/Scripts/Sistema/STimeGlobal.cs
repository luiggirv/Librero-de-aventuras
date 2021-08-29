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
    public static int LvlIngresado;

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
        if (PlayerPrefs.GetInt(LvlIngresado.ToString() + "a") < SScoreGlobal.ScoreCount)
        {
            PlayerPrefs.SetInt(LvlIngresado.ToString() + "a", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt(LvlIngresado.ToString() + "b", SScoreGlobal.EliminadosCount);
        }
        LevelSelect.lvl1Entrar = false;
        LevelSelect.lvl2Entrar = false;
        LevelSelect.lvl3Entrar = false;
        LevelSelect.lvl4Entrar = false;
        LevelSelect.lvl5Entrar = false;
        LevelSelect.lvl6Entrar = false;

        LevelSelect.lvl1EntrarCirculatorio = false;
        LevelSelect.lvl2EntrarCirculatorio = false;
        LevelSelect.lvl3EntrarCirculatorio = false;
        LevelSelect.lvl4EntrarCirculatorio = false;
        LevelSelect.lvl5EntrarCirculatorio = false;
        LevelSelect.lvl6EntrarCirculatorio = false;
}

    public void RegresarMenu()
    {
        if (PlayerPrefs.GetInt(LvlIngresado.ToString() + "a") < SScoreGlobal.ScoreCount)
        {
            PlayerPrefs.SetInt(LvlIngresado.ToString() + "a", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt(LvlIngresado.ToString() + "b", SScoreGlobal.EliminadosCount);
        }
        timeStart = 999;
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }

}
