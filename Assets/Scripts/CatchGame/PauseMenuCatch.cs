using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuCatch : MonoBehaviour
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
        AudioListener.pause = false;
        GameIsPause = false;
        Time.timeScale = 1f;
        if (LevelSelectEcosistema.lvl1MountainEntrar || LevelSelectEcosistema.lvl2MountainEntrar || LevelSelectEcosistema.lvl3MountainEntrar || LevelSelectEcosistema.lvl4MountainEntrar || LevelSelectEcosistema.lvl5MountainEntrar || LevelSelectEcosistema.lvl6MountainEntrar || LevelSelectEcosistema.lvlTutorialMountain)
        {
            SceneManager.LoadScene(13);
        }
        LevelSelectEcosistema.lvl1MountainEntrar = false;
        LevelSelectEcosistema.lvl2MountainEntrar = false;
        LevelSelectEcosistema.lvl3MountainEntrar = false;
        LevelSelectEcosistema.lvl4MountainEntrar = false;
        LevelSelectEcosistema.lvl5MountainEntrar = false;
        LevelSelectEcosistema.lvl6MountainEntrar = false;
        LevelSelectEcosistema.lvlTutorialMountain = false;
    }

    public bool isPause()
    {
        return GameIsPause;
    }

}
