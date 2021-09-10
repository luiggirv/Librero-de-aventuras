using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuLago : MonoBehaviour
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
        GameIsPause = false;
        Time.timeScale = 1f;
        if (LevelSelectEcosistema.lvl1LakeEntrar || LevelSelectEcosistema.lvl2LakeEntrar || LevelSelectEcosistema.lvl3LakeEntrar || LevelSelectEcosistema.lvl4LakeEntrar || LevelSelectEcosistema.lvl5LakeEntrar || LevelSelectEcosistema.lvl6LakeEntrar || LevelSelectEcosistema.lvlTutorialLake)
        {
            SceneManager.LoadScene(14);
        }
        LevelSelectEcosistema.lvl1LakeEntrar = false;
        LevelSelectEcosistema.lvl2LakeEntrar = false;
        LevelSelectEcosistema.lvl3LakeEntrar = false;
        LevelSelectEcosistema.lvl4LakeEntrar = false;
        LevelSelectEcosistema.lvl5LakeEntrar = false;
        LevelSelectEcosistema.lvl6LakeEntrar = false;

        AudioListener.pause = false;
    }

}
