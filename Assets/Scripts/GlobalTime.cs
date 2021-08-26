using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalTime : MonoBehaviour
{
    public float timeStart = 200;
    public GameObject TiempoReal;
    public static bool GameIsPause = false;
    public GameObject finNivelUI;
    public GameObject puntajeNivel;
    public GameObject puntajeTotal;

    public static int PuntajeLvl1;
    public static int PuntajeLvl2;
    public static int PuntajeLvl3;
    public static int PuntajeLvl4;
    public static int PuntajeLvl5;
    public static int PuntajeLvl6;

    void Start()
    {
        TiempoReal.GetComponent<Text>().text = timeStart.ToString() + " segundos";
        GameIsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        TiempoReal.GetComponent<Text>().text = Mathf.Round(timeStart).ToString() + " segundos";

        if (Mathf.Round(timeStart) == 0 && GameIsPause == false)
        {
            puntajeNivel.GetComponent<Text>().text = "Puntaje total: " + puntajeTotal.GetComponent<Text>().text;
            finNivelUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;            
        }
    }

    public void ContinuarNivel()
    {
        Time.timeScale = 1f;
        if (LevelSelectForest.lvl1Entrar == true)
        {
            LevelSelectForest.lvl1Superado = true;
            PuntajeLvl1 = GlobalScore.ScoreCount;
        }
        else if (LevelSelectForest.lvl2Entrar == true)
        {
            LevelSelectForest.lvl2Superado = true;
            PuntajeLvl2 = GlobalScore.ScoreCount;
        }
        else if (LevelSelectForest.lvl3Entrar == true)
        {
            LevelSelectForest.lvl3Superado = true;
            PuntajeLvl3 = GlobalScore.ScoreCount;
        }
        else if (LevelSelectForest.lvl4Entrar == true)
        {
            LevelSelectForest.lvl4Superado = true;
            PuntajeLvl4 = GlobalScore.ScoreCount;
        }
        else if (LevelSelectForest.lvl5Entrar == true)
        {
            LevelSelectForest.lvl5Superado = true;
            PuntajeLvl5 = GlobalScore.ScoreCount;
        }
        else if (LevelSelectForest.lvl6Entrar == true)
        {
            LevelSelectForest.lvl6Superado = true;
            PuntajeLvl6 = GlobalScore.ScoreCount;
        }
        //int[] myNum = {6,7};
        //int result = myNum[Random.Range(0, myNum.Length)];
        SceneManager.LoadScene(15);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
