using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

public class LeaderBoardControllerEcosistema : MonoBehaviour
{
    int leaderboardID = 571;
    int count = 10;
    public GameObject[] entradas;
    public GameObject loadingUI;
    void Start()
    {
        if (MapaSelect.BosqueEntrar)
        {
            leaderboardID = 523;
        }
        else if (MapaSelect.LagoEntrar)
        {
            leaderboardID = 524;
        }
        else
        {
            leaderboardID = 526;
        }
        getLeaderboard();
    }

    public void changeLvl1()
    {
        if (MapaSelect.BosqueEntrar)
        {
            leaderboardID = 523;
        }
        else if (MapaSelect.LagoEntrar)
        {
            leaderboardID = 524;
        }
        else
        {
            leaderboardID = 526;
        }
        getLeaderboard();
    }

    public void changeLvl2()
    {
        if (MapaSelect.BosqueEntrar)
        {
            leaderboardID = 543;
        }
        else if (MapaSelect.LagoEntrar)
        {
            leaderboardID = 548;
        }
        else
        {
            leaderboardID = 553;
        }
        getLeaderboard();
    }

    public void changeLvl3()
    {
        if (MapaSelect.BosqueEntrar)
        {
            leaderboardID = 544;
        }
        else if (MapaSelect.LagoEntrar)
        {
            leaderboardID = 549;
        }
        else
        {
            leaderboardID = 554;
        }
        getLeaderboard();
    }

    public void changeLvl4()
    {
        if (MapaSelect.BosqueEntrar)
        {
            leaderboardID = 545;
        }
        else if (MapaSelect.LagoEntrar)
        {
            leaderboardID = 550;
        }
        else
        {
            leaderboardID = 555;
        }
        getLeaderboard();
    }

    public void changeLvl5()
    {
        if (MapaSelect.BosqueEntrar)
        {
            leaderboardID = 546;
        }
        else if (MapaSelect.LagoEntrar)
        {
            leaderboardID = 551;
        }
        else
        {
            leaderboardID = 556;
        }
        getLeaderboard();
    }

    public void changeLvl6()
    {
        if (MapaSelect.BosqueEntrar)
        {
            leaderboardID = 547;
        }
        else if (MapaSelect.LagoEntrar)
        {
            leaderboardID = 552;
        }
        else
        {
            leaderboardID = 557;
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
        if (MapaSelect.BosqueEntrar)
        {
            SceneManager.LoadScene(15);
        }
        else if (MapaSelect.LagoEntrar)
        {
            SceneManager.LoadScene(14);
        }
        else
        {
            SceneManager.LoadScene(13);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
