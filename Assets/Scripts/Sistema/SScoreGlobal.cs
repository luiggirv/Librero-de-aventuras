using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SScoreGlobal : MonoBehaviour
{
    public static int ScoreCount;
    public GameObject PuntajeReal;
    public int InternalScore;
    public static int EliminadosCount;
    public GameObject EliminadosReal;
    public int InternalEliminados;

    // Start is called before the first frame update
    void Start()
    {
        InternalScore = 0;
        InternalEliminados = 0;
        PuntajeReal.GetComponent<Text>().text = InternalScore.ToString();
        EliminadosReal.GetComponent<Text>().text = InternalEliminados.ToString();
    }

    void OnLevelWasLoaded()
    {
       EliminadosCount = 0;
       ScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InternalScore = ScoreCount;
        PuntajeReal.GetComponent<Text>().text = InternalScore.ToString();
        InternalEliminados = EliminadosCount;
        EliminadosReal.GetComponent<Text>().text = InternalEliminados.ToString();
    }
}
