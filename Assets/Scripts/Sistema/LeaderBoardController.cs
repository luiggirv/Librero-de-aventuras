using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

public class LeaderBoardController : MonoBehaviour
{
    int leaderboardID = 571;
    int count = 10;
    public GameObject[] entradas;
    public GameObject loadingUI;
    void Start()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            leaderboardID = 520;
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            leaderboardID = 521;
        }
        else
        {
            leaderboardID = 522;

        }
        getLeaderboard();
    }

    public void changeLvl1()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            leaderboardID = 520;
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            leaderboardID = 521;
        }
        else
        {
            leaderboardID = 522;

        }
        getLeaderboard();
    }

    public void changeLvl2()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            leaderboardID = 528;
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            leaderboardID = 533;
        }
        else
        {
            leaderboardID = 538;
        }
        getLeaderboard();
    }

    public void changeLvl3()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            leaderboardID = 529;
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            leaderboardID = 534;
        }
        else
        {
            leaderboardID = 539;
        }
        getLeaderboard();
    }

    public void changeLvl4()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            leaderboardID = 530;
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            leaderboardID = 535;
        }
        else
        {
            leaderboardID = 540;
        }
        getLeaderboard();
    }

    public void changeLvl5()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            leaderboardID = 531;
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            leaderboardID = 536;
        }
        else
        {
            leaderboardID = 541;
        }
        getLeaderboard();
    }

    public void changeLvl6()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            leaderboardID = 532;
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            leaderboardID = 537;
        }
        else
        {
            leaderboardID = 542;
        }
        getLeaderboard();
    }

    public void getLeaderboard()
    {
        if (PlayerPrefs.HasKey("GUID"))
        {
            loadingUI.SetActive(true);
            string ID = PlayerPrefs.GetString("GUID");
            LootLockerSDKManager.StartSession(ID, (response) =>
            {
                if (response.success)
                {
                    LootLockerSDKManager.GetScoreList(leaderboardID, count, (response) => {
                        if (response.success)
                        {
                            limpiarTexto();
                            LootLockerLeaderboardMember[] scores = response.items;

                            for (int i = 0; i < scores.Length; i++)
                            {
                                entradas[i].GetComponent<Text>().text = scores[i].rank + ") " + scores[i].player.name + ": " + scores[i].score;
                            }

                            Debug.Log("Leaderboard cargado " + leaderboardID);
                        }
                        else
                        {
                            Debug.Log("Failed: " + response.Error);
                        }
                        loadingUI.SetActive(false);
                    });
                }
                else
                {
                    loadingUI.SetActive(false);
                    Debug.Log("Failed" + response.Error);
                }
            });
        }
    }

    public void limpiarTexto()
    {
        for (int i = 0; i < count; i++)
        {
            entradas[i].GetComponent<Text>().text = "";
        }
    }

    public void regresarMenu()
    {
        if (SistemaSelect.SistemaRespiratorioEntrar)
        {
            SceneManager.LoadScene(8);
        }
        else if (SistemaSelect.SistemaCirculatorioEntrar)
        {
            SceneManager.LoadScene(26);
        }
        else
        {
            SceneManager.LoadScene(33);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
