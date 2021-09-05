using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game state manager, keeps track of the <see cref="Artifact"/> health and clocks the time to win.
/// </summary>
public class Manager : MonoBehaviour
{
    public float timeToWin;
    public Artifact artifact;
    SceneManagerTower sceneManager;
    float timer;

    void Awake()
    {
        timer = timeToWin;
        sceneManager = GetComponent<SceneManagerTower>();
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
        sceneManager.ChangeScene(3);
    }
    void Win()
    {
        sceneManager.ChangeScene(4);
    }
    public float GetTime()
    {
        return timer;
    }
}
