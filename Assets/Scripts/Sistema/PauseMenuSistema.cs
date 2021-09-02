using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuSistema : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    public void Resume()
    {
        AudioListener.pause = false;
        var clones = GameObject.FindGameObjectsWithTag("Virus");
        foreach (var clone in clones)
        {
            clone.GetComponent<PolygonCollider2D>().enabled = true;
            clone.GetComponent<Renderer>().sortingOrder = 6;
        }
        var clonesObjetos = GameObject.FindGameObjectsWithTag("Objeto");
        foreach (var clone in clonesObjetos)
        {
            clone.GetComponent<PolygonCollider2D>().enabled = true;
            clone.GetComponent<Renderer>().sortingOrder = 6;
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void Pause()
    {
        AudioListener.pause = true;
        var clones = GameObject.FindGameObjectsWithTag("Virus");
        foreach (var clone in clones)
        {
            clone.GetComponent<PolygonCollider2D>().enabled = false;
            clone.GetComponent<Renderer>().sortingOrder = 4;
        }
        var clonesObjetos = GameObject.FindGameObjectsWithTag("Objeto");
        foreach (var clone in clonesObjetos)
        {
            clone.GetComponent<PolygonCollider2D>().enabled = false;
            clone.GetComponent<Renderer>().sortingOrder = 4;
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu()
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
        Time.timeScale = 1f;
        if (LevelSelect.lvl1Entrar || LevelSelect.lvl2Entrar || LevelSelect.lvl3Entrar || LevelSelect.lvl4Entrar || LevelSelect.lvl5Entrar || LevelSelect.lvl6Entrar||LevelSelect.lvlTutorialRespiratorio)
        {
            SceneManager.LoadScene(8);
        }
        else if (LevelSelect.lvl1EntrarCirculatorio || LevelSelect.lvl2EntrarCirculatorio || LevelSelect.lvl3EntrarCirculatorio || LevelSelect.lvl4EntrarCirculatorio || LevelSelect.lvl5EntrarCirculatorio || LevelSelect.lvl6EntrarCirculatorio|| LevelSelect.lvlTutorialCirculatorio)
        {
            SceneManager.LoadScene(26);
        }
        else if (LevelSelect.lvl1EntrarNervioso || LevelSelect.lvl2EntrarNervioso || LevelSelect.lvl3EntrarNervioso || LevelSelect.lvl4EntrarNervioso || LevelSelect.lvl5EntrarNervioso || LevelSelect.lvl6EntrarNervioso|| LevelSelect.lvlTutorialNervioso)
        {
            SceneManager.LoadScene(33);
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

        LevelSelect.lvl1EntrarNervioso = false;
        LevelSelect.lvl2EntrarNervioso = false;
        LevelSelect.lvl3EntrarNervioso = false;
        LevelSelect.lvl4EntrarNervioso = false;
        LevelSelect.lvl5EntrarNervioso = false;
        LevelSelect.lvl6EntrarNervioso = false;

        LevelSelect.lvlTutorialCirculatorio = false;
        LevelSelect.lvlTutorialNervioso = false;
        LevelSelect.lvlTutorialRespiratorio = false;

        AudioListener.pause = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
