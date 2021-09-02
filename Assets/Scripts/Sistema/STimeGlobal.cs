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
    public float quitarTiempo;

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
        if (LugarGlobal.lugarEquivocado)
        {
            LugarGlobal.lugarEquivocado = false;
            if (timeStart - quitarTiempo <= 0)
            {
                timeStart = 0;
            }
            else
            {
                timeStart -= quitarTiempo;
            }
        }

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
        if (PlayerPrefs.GetInt(LvlIngresado.ToString() + "a") < SScoreGlobal.ScoreCount)
        {
            PlayerPrefs.SetInt(LvlIngresado.ToString() + "a", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt(LvlIngresado.ToString() + "b", SScoreGlobal.EliminadosCount);
        }
        if (LevelSelect.lvl1Entrar|| LevelSelect.lvl2Entrar|| LevelSelect.lvl3Entrar|| LevelSelect.lvl4Entrar|| LevelSelect.lvl5Entrar|| LevelSelect.lvl6Entrar)
        {
            SceneManager.LoadScene(8);
        }
        else if (LevelSelect.lvl1EntrarCirculatorio|| LevelSelect.lvl2EntrarCirculatorio|| LevelSelect.lvl3EntrarCirculatorio|| LevelSelect.lvl4EntrarCirculatorio|| LevelSelect.lvl5EntrarCirculatorio|| LevelSelect.lvl6EntrarCirculatorio)
        {
            SceneManager.LoadScene(26);
        }
        else if (LevelSelect.lvl1EntrarNervioso|| LevelSelect.lvl2EntrarNervioso|| LevelSelect.lvl3EntrarNervioso|| LevelSelect.lvl4EntrarNervioso|| LevelSelect.lvl5EntrarNervioso|| LevelSelect.lvl6EntrarNervioso)
        {
            SceneManager.LoadScene(33);
        }
        timeStart = 999;

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

        LevelSelect.lvl1EntrarNervioso = false;
        LevelSelect.lvl2EntrarNervioso = false;
        LevelSelect.lvl3EntrarNervioso = false;
        LevelSelect.lvl4EntrarNervioso = false;
        LevelSelect.lvl5EntrarNervioso = false;
        LevelSelect.lvl6EntrarNervioso = false;
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

        LevelSelect.lvl1EntrarNervioso = false;
        LevelSelect.lvl2EntrarNervioso = false;
        LevelSelect.lvl3EntrarNervioso = false;
        LevelSelect.lvl4EntrarNervioso = false;
        LevelSelect.lvl5EntrarNervioso = false;
        LevelSelect.lvl6EntrarNervioso = false;
        SceneManager.LoadScene(4);
    }

}
