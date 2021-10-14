using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

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
            puntajeNivelFinal.GetComponent<Text>().text = "Puntaje total: " + puntajeTotal.GetComponent<Text>().text + "\nNúmero de virus eliminados: " + SScoreGlobal.EliminadosCount;
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
                        data.AddToPayload(new LootLockerPayload
                        {
                            key = LvlIngresado.ToString() + "b",
                            value = PlayerPrefs.GetInt(LvlIngresado.ToString() + "b").ToString(),
                            is_public = true
                        });
                        LootLockerSDKManager.UpdateOrCreateKeyValue(data, (getPersistentStoragResponse) =>
                        {
                            if (getPersistentStoragResponse.success)
                            {
                                Debug.Log("Puntaje del nivel actualizado");
                            }
                            else
                            {
                                Debug.Log("Error al actualizar el puntaje del nivel");
                            }
                        });

                        int leaderboardID = 571;
                        switch (LvlIngresado)
                        {
                            case 101:
                                leaderboardID = 520;
                                break;
                            case 102:
                                leaderboardID = 528;
                                break;
                            case 103:
                                leaderboardID = 529;
                                break;
                            case 104:
                                leaderboardID = 530;
                                break;
                            case 105:
                                leaderboardID = 531;
                                break;
                            case 106:
                                leaderboardID = 532;
                                break;
                            case 201:
                                leaderboardID = 521;
                                break;
                            case 202:
                                leaderboardID = 533;
                                break;
                            case 203:
                                leaderboardID = 534;
                                break;
                            case 204:
                                leaderboardID = 535;
                                break;
                            case 205:
                                leaderboardID = 536;
                                break;
                            case 206:
                                leaderboardID = 537;
                                break;
                            case 301:
                                leaderboardID = 522;
                                break;
                            case 302:
                                leaderboardID = 538;
                                break;
                            case 303:
                                leaderboardID = 539;
                                break;
                            case 304:
                                leaderboardID = 540;
                                break;
                            case 305:
                                leaderboardID = 541;
                                break;
                            case 306:
                                leaderboardID = 542;
                                break;
                        }
                        LootLockerSDKManager.SubmitScore(ID, PlayerPrefs.GetInt(LvlIngresado.ToString() + "a"), leaderboardID, (response) =>
                        {
                            if (response.success)
                            {
                                Debug.Log("Puntaje guardado en el Leaderboard");
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
                        data.AddToPayload(new LootLockerPayload
                        {
                            key = LvlIngresado.ToString() + "b",
                            value = PlayerPrefs.GetInt(LvlIngresado.ToString() + "b").ToString(),
                            is_public = true
                        });
                        LootLockerSDKManager.UpdateOrCreateKeyValue(data, (getPersistentStoragResponse) =>
                        {
                            if (getPersistentStoragResponse.success)
                            {
                                Debug.Log("Puntaje del nivel actualizado");
                            }
                            else
                            {
                                Debug.Log("Error al actualizar el puntaje del nivel");
                            }
                        });
                        int leaderboardID = 571;
                        switch (LvlIngresado)
                        {
                            case 101:
                                leaderboardID = 520;
                                break;
                            case 102:
                                leaderboardID = 528;
                                break;
                            case 103:
                                leaderboardID = 529;
                                break;
                            case 104:
                                leaderboardID = 530;
                                break;
                            case 105:
                                leaderboardID = 531;
                                break;
                            case 106:
                                leaderboardID = 532;
                                break;
                            case 201:
                                leaderboardID = 521;
                                break;
                            case 202:
                                leaderboardID = 533;
                                break;
                            case 203:
                                leaderboardID = 534;
                                break;
                            case 204:
                                leaderboardID = 535;
                                break;
                            case 205:
                                leaderboardID = 536;
                                break;
                            case 206:
                                leaderboardID = 537;
                                break;
                            case 301:
                                leaderboardID = 522;
                                break;
                            case 302:
                                leaderboardID = 538;
                                break;
                            case 303:
                                leaderboardID = 539;
                                break;
                            case 304:
                                leaderboardID = 540;
                                break;
                            case 305:
                                leaderboardID = 541;
                                break;
                            case 306:
                                leaderboardID = 542;
                                break;
                        }
                        LootLockerSDKManager.SubmitScore(ID, PlayerPrefs.GetInt(LvlIngresado.ToString() + "a"), leaderboardID, (response) =>
                           {
                               if (response.success)
                               {
                                   Debug.Log("Puntaje guardado en el Leaderboard");
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

        SistemaSelect.SistemaCirculatorioEntrar = false;
        SistemaSelect.SistemaRespiratorioEntrar = false;
        SistemaSelect.SistemaNerviosoEntrar = false;

        SceneManager.LoadScene(4);
    }

}
