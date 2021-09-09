using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public float timeToWin;
    public Artifact artifact;
    float timer;
    public GameObject gameOverUI;
    public GameObject PuntajeFinalText;
    public static int LvlIngresado;

    void Awake()
    {
        timer = timeToWin;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        ScoreGlobalTower.ScoreCount += Time.deltaTime;
        if (artifact.health <= 0)
        {
            Lose();
        }

        if(timer <= 0)
        {
            Win();
        }
    }

    void Lose()
    {
        PuntajeFinalText.GetComponent<Text>().text = "La vida del corral llegó a 0 de vida por los animales salvajes";
        AudioListener.pause = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    void Win()
    {
        PuntajeFinalText.GetComponent<Text>().text = "Puntaje Final: " + (Mathf.Round(ScoreGlobalTower.ScoreCount)*100).ToString();
        if (PlayerPrefs.GetInt(LvlIngresado.ToString() + "a") < (int) (Mathf.Round(ScoreGlobalTower.ScoreCount) * 100))
        {
            PlayerPrefs.SetInt(LvlIngresado.ToString() + "a", (int) Mathf.Round(ScoreGlobalTower.ScoreCount) * 100);
        }
        AudioListener.pause = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        if (LevelSelectEcosistema.lvl1ForestEntrar || LevelSelectEcosistema.lvl2ForestEntrar || LevelSelectEcosistema.lvl3ForestEntrar || LevelSelectEcosistema.lvl4ForestEntrar || LevelSelectEcosistema.lvl5ForestEntrar || LevelSelectEcosistema.lvl6ForestEntrar || LevelSelectEcosistema.lvlTutorialForest)
        {
            SceneManager.LoadScene(15);
        }
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl2ForestEntrar = false;
        LevelSelectEcosistema.lvl3ForestEntrar = false;
        LevelSelectEcosistema.lvl4ForestEntrar = false;
        LevelSelectEcosistema.lvl5ForestEntrar = false;
        LevelSelectEcosistema.lvl6ForestEntrar = false;
        LevelSelectEcosistema.lvlTutorialForest = false;

        AudioListener.pause = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl2ForestEntrar = false;
        LevelSelectEcosistema.lvl3ForestEntrar = false;
        LevelSelectEcosistema.lvl4ForestEntrar = false;
        LevelSelectEcosistema.lvl5ForestEntrar = false;
        LevelSelectEcosistema.lvl6ForestEntrar = false;
        LevelSelectEcosistema.lvlTutorialForest = false;

        AudioListener.pause = false;
    }
    public float GetTime()
    {
        return timer;
    }
}
