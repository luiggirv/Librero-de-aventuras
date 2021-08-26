using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{
    public static int ScoreCount;
    public GameObject PuntajeReal;
    public int InternalScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InternalScore = ScoreCount;
        PuntajeReal.GetComponent<Text>().text = InternalScore.ToString();
    }
}
