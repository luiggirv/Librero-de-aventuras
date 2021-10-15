using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LootLocker.Requests;

public class LeaderBoardControllerEcosistema : MonoBehaviour
{
    int leaderboardID = 571;
    int count = 30;
    public GameObject[] entradas;
    public GameObject loadingUI;
    public GameObject[] botones;
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
        aclararBotones(0);
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
        aclararBotones(0);
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
        aclararBotones(1);
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
        aclararBotones(2);
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
        aclararBotones(3);
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
        aclararBotones(4);
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
        aclararBotones(5);
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
            entradas[i].GetComponent<Text>().text = (i+1) + ") ";
        }
    }

    public void aclararBotones(int number)
    {
        for (int i = 0; i < botones.Length; i++)
        {
            if (i != number)
            {
                botones[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                botones[i].GetComponent<Image>().color = new Color32(154, 154, 154, 154);
            }
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
