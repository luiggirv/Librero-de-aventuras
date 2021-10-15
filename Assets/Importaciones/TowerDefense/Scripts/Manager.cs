using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LootLocker.Requests;
public class Manager : MonoBehaviour
{
    public float timeToWin;
    public Artifact artifact;
    float timer;
    public GameObject gameOverUI;
    public GameObject PuntajeFinalText;
    public static int LvlIngresado;

    void Start()
    {
        Application.targetFrameRate = 60;
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
            
            //Para actualizar datos online
            if (PlayerPrefs.HasKey("GUID"))
            {
                string ID = PlayerPrefs.GetString("GUID");
                LootLockerSDKManager.StartSession(ID, (response) =>
                {
                    if (response.success)
                    {
                        LootLockerGetPersistentStorageRequest data = new LootLockerGetPersistentStorageRequest();
                        data.AddToPayload(new LootLockerPayload
                        {
                            key = LvlIngresado.ToString() + "a",
                            value = PlayerPrefs.GetInt(LvlIngresado.ToString() + "a").ToString(),
                            is_public = true
                        });
                        LootLockerSDKManager.UpdateOrCreateKeyValue(data, (getPersistentStoragResponse) =>
                        {
                            if (getPersistentStoragResponse.success)
                            {
                                //Debug.Log("Puntaje del nivel actualizado");
                            }
                            else
                            {
                                Debug.Log("Error al actualizar el puntaje del nivel");
                            }
                        });

                        int leaderboardID = 571;
                        switch (LvlIngresado)
                        {
                            case 401:
                                leaderboardID = 523;
                                break;
                            case 402:
                                leaderboardID = 543;
                                break;
                            case 403:
                                leaderboardID = 544;
                                break;
                            case 404:
                                leaderboardID = 545;
                                break;
                            case 405:
                                leaderboardID = 546;
                                break;
                            case 406:
                                leaderboardID = 547;
                                break;
                        }
                        LootLockerSDKManager.SubmitScore(ID, PlayerPrefs.GetInt(LvlIngresado.ToString() + "a"), leaderboardID, (response) =>
                        {
                            if (response.success)
                            {
                                //Debug.Log("Puntaje guardado en el Leaderboard");
                            }
                            else
                            {
                                Debug.Log("Error al guardar puntaje en el Leaderboard");
                            }
                        }
                        );
                    }
                    else
                    {
                        Debug.Log("Failed" + response.Error);
                    }
                });
            }
        }
        AudioListener.pause = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
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
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(1);
        LevelSelectEcosistema.lvl1ForestEntrar = false;
        LevelSelectEcosistema.lvl2ForestEntrar = false;
        LevelSelectEcosistema.lvl3ForestEntrar = false;
        LevelSelectEcosistema.lvl4ForestEntrar = false;
        LevelSelectEcosistema.lvl5ForestEntrar = false;
        LevelSelectEcosistema.lvl6ForestEntrar = false;
        LevelSelectEcosistema.lvlTutorialForest = false;
    }
    public float GetTime()
    {
        return timer;
    }
}
