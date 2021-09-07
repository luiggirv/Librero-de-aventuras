using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuEcosistema : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    public void Resume()
    {
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void Pause()
    {
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        if (LevelSelectEcosistema.lvl1ForestEntrar || LevelSelectEcosistema.lvl2ForestEntrar || LevelSelectEcosistema.lvl3ForestEntrar || LevelSelectEcosistema.lvl4ForestEntrar || LevelSelectEcosistema.lvl5ForestEntrar || LevelSelectEcosistema.lvl6ForestEntrar || LevelSelectEcosistema.lvlTutorialForest)
        {
            SceneManager.LoadScene(15);
        }
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl1ForestEntrar = false;

        AudioListener.pause = false;
    }

}
