using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameplayManager : MonoBehaviour
{

    public static GameplayManager instance;
    public static bool success = false;
    public Text countdownText;

    public int countdownTimer = 60;

    [SerializeField]
    private Text scoreText;

    private int scoreCount;
    public static int allScore = 0;

    [SerializeField]
    private Image scoreFillUI;
    public static int thisLevel;

    public static int levelReached = 1;
    public SceneFader fader;
    private int levelTutorial;
    private int level1;
    private int level2;
    private int level3;
    private int level4;
    private int level5;
    private int level6;
    private float sumScoreInThisLvl;
    private bool done = false;
    private bool StopCount = false;

    public int nRespuestaCorrecta;
    public static bool GameIsPause = false;
    public GameObject PreguntaBG;
    public GameObject PreguntaTxt;
    public GameObject Respuesta1Txt;
    public GameObject Respuesta2Txt;
    public GameObject Respuesta3Txt;
    public GameObject Respuesta4Txt;
    public GameObject continuarButton;
    private bool startLevel;

    public static int LvlIngresado;

    QuestionsGenerate preguntaGenerada ;
    QuestionsGenerate.PreguntasAcuaticos preguntaRecogida;

    public AudioSource correctSound;
    public AudioSource wrongSound;

    public bool preguntasSonAcuaticas = false;
    public bool preguntasSonReciclaje = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        GameIsPause = false;
        AudioListener.pause = false;
        preguntaGenerada = GetComponentInChildren<QuestionsGenerate>();
        startLevel = true;
        sumScoreInThisLvl = 0f;
        PreguntaBG.SetActive(false);

        formula(false);
        done = false;

        DisplayScore(0);

        thisLevel = SceneManager.GetActiveScene().buildIndex;

        countdownText.text = countdownTimer.ToString();

        StartCoroutine("Countdown");

    }

    IEnumerator Countdown()
    {
        if (startLevel)
        {
            resetLevel();
            startLevel = false;
        }
        if (countdownTimer <= 0)
        {
            yield return new WaitForSeconds(1f);
        }
        else if (PauseMenuLago.GameIsPause || TutorialLago.GameIsPause)
        {
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSecondsRealtime(1f);
        }

        StopCount = false;

        countdownTimer -= 1;

        countdownText.text = countdownTimer.ToString();

        if (countdownTimer <= 10)
        {
            SoundManager.instance.TimeRunningOut(true);
        }

        StartCoroutine("Countdown");

        if (countdownTimer <= 0)
        {
            StopCoroutine("Countdown");
            SoundManager.instance.GameEnd();
            SoundManager.instance.TimeRunningOut(false);

            GameObject lossTxt = GameObject.Find("loseTxt");
            lossTxt.GetComponent<Text>().enabled = true;

            LevelSelectEcosistema.lvl1LakeEntrar = false;
            LevelSelectEcosistema.lvl2LakeEntrar = false;
            LevelSelectEcosistema.lvl3LakeEntrar = false;
            LevelSelectEcosistema.lvl4LakeEntrar = false;
            LevelSelectEcosistema.lvl5LakeEntrar = false;
            LevelSelectEcosistema.lvl6LakeEntrar = false;
            LevelSelectEcosistema.lvlTutorialLake = false;

            success = false;
            StopCount = true;
            HookScript.itemValue = "";
            Resume(-1);

            StartCoroutine(RestartGame(999));
        }

    }

    private void resetLevel()
    {
        level1 = 0;
        level2 = 0;
        level3 = 0;
        level4 = 0;
        GameObject winTxt = GameObject.Find("winTxt");
        winTxt.GetComponent<Text>().enabled = false;
        GameObject lossTxt = GameObject.Find("loseTxt");
        lossTxt.GetComponent<Text>().enabled = false;
    }

    public void DisplayScore(int scoreValue)
    {

        if (scoreText == null)
            return;
        if (StopCount)
            return;
        if (scoreValue == 999)
        {
            scoreValue = 0;
            scoreCount -= 100;
            allScore -= 100;
            //if (scoreCount - 100 < 0) // Por si no se quiere obtener puntaje negativo
            //{
            //    scoreCount -= 0;
            //    allScore -= 0;
            //}
            //else
            //{
            //    scoreCount -= 100;
            //    allScore -= 100;
            //}
            scoreText.text = scoreCount.ToString();
            if (countdownTimer > 10)
            {
                countdownTimer -= 10;
            }
            else
            {
                StopCoroutine("Countdown");
                SoundManager.instance.GameEnd();
                SoundManager.instance.TimeRunningOut(false);
                GameObject lossTxt = GameObject.Find("loseTxt");
                lossTxt.GetComponent<Text>().enabled = true;
                success = false;
                StopCount = true;
                StartCoroutine(RestartGame(999));
            }
        }
        else
        {
            formula(true);
        }
            scoreCount += scoreValue;
            allScore += scoreValue;
            scoreText.text = scoreCount.ToString();


        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 7:
                if (level1 == 5) done = true;
                break;
            case 49:
                if (level2 == 7) done = true;
                break;
            case 50:
                if (level3 == 7) done = true;
                break;
            case 51:
                if (level4 == 7) done = true;
                break;
            case 52:
                if (level5 == 7) done = true;
                break;
            case 53:
                if (level6 == 8) done = true;
                break;
            case 54:
                if (levelTutorial == 2) done = true;  //Nivel de Tutorial
                break;

        }

    }

    private void formula(bool show)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 7:
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                    case "four":
                    case "mult":
                    case "three":
                    case "six":
                        level1++;
                        PreguntaBG.SetActive(true);
                        if (preguntasSonAcuaticas)
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasActuaticos();
                        }
                        else
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasReciclaje();
                        }
                        nRespuestaCorrecta = preguntaRecogida.numRespuesta;
                        PreguntaTxt.GetComponent<Text>().text = preguntaRecogida.pregunta;
                        Respuesta1Txt.GetComponent<Text>().text = preguntaRecogida.respuesta1;
                        Respuesta2Txt.GetComponent<Text>().text = preguntaRecogida.respuesta2;
                        Respuesta3Txt.GetComponent<Text>().text = preguntaRecogida.respuesta3;
                        Respuesta4Txt.GetComponent<Text>().text = preguntaRecogida.respuesta4;
                        Time.timeScale = 0f;
                        GameIsPause = true;
                    break;
                }
                break;
            case 49:
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                    case "four":
                    case "mult":
                    case "three":
                    case "six":
                        level2++;
                        PreguntaBG.SetActive(true);
                        if (preguntasSonAcuaticas)
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasActuaticos();
                        }
                        else
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasReciclaje();
                        }
                        nRespuestaCorrecta = preguntaRecogida.numRespuesta;
                        PreguntaTxt.GetComponent<Text>().text = preguntaRecogida.pregunta;
                        Respuesta1Txt.GetComponent<Text>().text = preguntaRecogida.respuesta1;
                        Respuesta2Txt.GetComponent<Text>().text = preguntaRecogida.respuesta2;
                        Respuesta3Txt.GetComponent<Text>().text = preguntaRecogida.respuesta3;
                        Respuesta4Txt.GetComponent<Text>().text = preguntaRecogida.respuesta4;
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                }
                break;
            case 50:
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                    case "four":
                    case "mult":
                    case "three":
                    case "six":
                        level3++;
                        PreguntaBG.SetActive(true);
                        if (preguntasSonAcuaticas)
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasActuaticos();
                        }
                        else
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasReciclaje();
                        }
                        nRespuestaCorrecta = preguntaRecogida.numRespuesta;
                        PreguntaTxt.GetComponent<Text>().text = preguntaRecogida.pregunta;
                        Respuesta1Txt.GetComponent<Text>().text = preguntaRecogida.respuesta1;
                        Respuesta2Txt.GetComponent<Text>().text = preguntaRecogida.respuesta2;
                        Respuesta3Txt.GetComponent<Text>().text = preguntaRecogida.respuesta3;
                        Respuesta4Txt.GetComponent<Text>().text = preguntaRecogida.respuesta4;
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                }
                break;
            case 51:
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                    case "four":
                    case "mult":
                    case "three":
                    case "six":
                        level4++;
                        PreguntaBG.SetActive(true);
                        if (preguntasSonAcuaticas)
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasActuaticos();
                        }
                        else
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasReciclaje();
                        }
                        nRespuestaCorrecta = preguntaRecogida.numRespuesta;
                        PreguntaTxt.GetComponent<Text>().text = preguntaRecogida.pregunta;
                        Respuesta1Txt.GetComponent<Text>().text = preguntaRecogida.respuesta1;
                        Respuesta2Txt.GetComponent<Text>().text = preguntaRecogida.respuesta2;
                        Respuesta3Txt.GetComponent<Text>().text = preguntaRecogida.respuesta3;
                        Respuesta4Txt.GetComponent<Text>().text = preguntaRecogida.respuesta4;
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                }
                break;
            case 52:
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                    case "four":
                    case "mult":
                    case "three":
                    case "six":
                        level5++;
                        PreguntaBG.SetActive(true);
                        if (preguntasSonAcuaticas)
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasActuaticos();
                        }
                        else
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasReciclaje();
                        }
                        nRespuestaCorrecta = preguntaRecogida.numRespuesta;
                        PreguntaTxt.GetComponent<Text>().text = preguntaRecogida.pregunta;
                        Respuesta1Txt.GetComponent<Text>().text = preguntaRecogida.respuesta1;
                        Respuesta2Txt.GetComponent<Text>().text = preguntaRecogida.respuesta2;
                        Respuesta3Txt.GetComponent<Text>().text = preguntaRecogida.respuesta3;
                        Respuesta4Txt.GetComponent<Text>().text = preguntaRecogida.respuesta4;
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                }
                break;
            case 53:
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                    case "four":
                    case "mult":
                    case "three":
                    case "six":
                        level6++;
                        PreguntaBG.SetActive(true);
                        if (preguntasSonAcuaticas)
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasActuaticos();
                        }
                        else
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasReciclaje();
                        }
                        nRespuestaCorrecta = preguntaRecogida.numRespuesta;
                        PreguntaTxt.GetComponent<Text>().text = preguntaRecogida.pregunta;
                        Respuesta1Txt.GetComponent<Text>().text = preguntaRecogida.respuesta1;
                        Respuesta2Txt.GetComponent<Text>().text = preguntaRecogida.respuesta2;
                        Respuesta3Txt.GetComponent<Text>().text = preguntaRecogida.respuesta3;
                        Respuesta4Txt.GetComponent<Text>().text = preguntaRecogida.respuesta4;
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                }
                break;
            case 54:
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                    case "four":
                    case "mult":
                    case "three":
                    case "six":
                        levelTutorial++;
                        PreguntaBG.SetActive(true);
                        if (preguntasSonAcuaticas)
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasActuaticos();
                        }
                        else
                        {
                            preguntaRecogida = preguntaGenerada.DevolverPreguntasReciclaje();
                        }
                        nRespuestaCorrecta = preguntaRecogida.numRespuesta;
                        PreguntaTxt.GetComponent<Text>().text = preguntaRecogida.pregunta;
                        Respuesta1Txt.GetComponent<Text>().text = preguntaRecogida.respuesta1;
                        Respuesta2Txt.GetComponent<Text>().text = preguntaRecogida.respuesta2;
                        Respuesta3Txt.GetComponent<Text>().text = preguntaRecogida.respuesta3;
                        Respuesta4Txt.GetComponent<Text>().text = preguntaRecogida.respuesta4;
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                }
                break;

        }
    }

    public void Resume(int itemTag)
    {
        if (itemTag == nRespuestaCorrecta) {
            correctSound.Play();
            scoreCount += 200;
            allScore += 200;
            scoreText.text = scoreCount.ToString();
        }
        else
        {
            wrongSound.Play();
        }
        PreguntaBG.SetActive(false);
        if (done)
        {
            StopCoroutine("Countdown");
            SoundManager.instance.GameEnd();
            HookScript.itemValue = "";
            success = true;
            scoreCount += countdownTimer * 100;
            scoreText.text = scoreCount.ToString();
            if (PlayerPrefs.GetInt(LvlIngresado.ToString() + "a") < scoreCount)
            {
                PlayerPrefs.SetInt(LvlIngresado.ToString() + "a", scoreCount);
            }
            GameObject winTxt = GameObject.Find("winTxt");
            winTxt.GetComponent<Text>().text = "Nivel finalizado\nPuntaje adicional por tiempo: " + (countdownTimer*100).ToString() +"\nPuntaje final: " + scoreText.text;
            winTxt.GetComponent<Text>().enabled = true;
            continuarButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            GameIsPause = false;
        }

    }

    public void Continuar()
    {
        LevelSelectEcosistema.lvl1LakeEntrar = false;
        LevelSelectEcosistema.lvl2LakeEntrar = false;
        LevelSelectEcosistema.lvl3LakeEntrar = false;
        LevelSelectEcosistema.lvl4LakeEntrar = false;
        LevelSelectEcosistema.lvl5LakeEntrar = false;
        LevelSelectEcosistema.lvl6LakeEntrar = false;
        LevelSelectEcosistema.lvlTutorialLake = false;

        PreguntaBG.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        SceneManager.LoadScene(14);
    }

    IEnumerator RestartGame(int scene)
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(14);
    }

    public int actualScore()
    {
        return scoreCount;
    }

    public void setTextGameObject()
    {
        var scoreTextSend = new GameObject();
        scoreTextSend.AddComponent<Text>();
        scoreText = scoreTextSend.GetComponent<Text>();
    }

}
