using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGlobalTower : MonoBehaviour
{
    public GameObject PuntajeReal;
    public float InternalScore;
    public static float ScoreCount;

    void Start()
    {
        InternalScore = 0;
        PuntajeReal.GetComponent<Text>().text = "Puntaje\n" + InternalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreCount += Time.deltaTime;
        InternalScore = Mathf.Round(ScoreCount);
        if (InternalScore < 0)
        {
            InternalScore = 0;
        }
        PuntajeReal.GetComponent<Text>().text = "Puntaje\n" + (InternalScore * 100).ToString();
    }
}
