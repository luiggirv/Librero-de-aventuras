﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameplayManager : MonoBehaviour
{

    public static GameplayManager instance;
    public static bool success = false;
    [SerializeField]
    private Text countdownText;

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
    private int level1;
    private int level2;
    private int level3;
    private int level4;
    //private int level5;
    //private int level6;
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

    public static int PuntajeLvl1;
    public static int PuntajeLvl2;
    public static int PuntajeLvl3;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // קורה לפני תחילת המשחק
    void Start()
    {
        startLevel = true;
        sumScoreInThisLvl = 0f;
        PreguntaBG.SetActive(false);

        //level5 = 0;
        //level6 = 0;
        formula(false);
        //resetFormula();
        done = false;

        DisplayScore(0);

        thisLevel = SceneManager.GetActiveScene().buildIndex;

        countdownText.text = countdownTimer.ToString();

        StartCoroutine("Countdown");



    }

    //private void showOperators()
    //{
    //    GameObject plus = GameObject.Find("plus");
    //    GameObject plus2 = GameObject.Find("plus2");
    //    GameObject mult = GameObject.Find("mult");
    //    GameObject minus = GameObject.Find("minus");
    //    GameObject divide = GameObject.Find("divide");
    //    GameObject mult2 = GameObject.Find("mult2");

    //    switch (SceneManager.GetActiveScene().buildIndex)
    //    {
    //        case 1:
    //            //"plus":
    //            plus.GetComponent<Text>().enabled = true;
    //            //"mult":
    //            mult.GetComponent<Text>().enabled = true;
    //            break;
    //        case 2:
    //            //"plus":
    //            plus.GetComponent<Text>().enabled = true;
    //            //"plus2":
    //            plus2.GetComponent<Text>().enabled = true;
    //            //"mult":
    //            mult.GetComponent<Text>().enabled = true;
    //            //"minus":
    //            minus.GetComponent<Text>().enabled = true;
    //            break;
    //        case 3:
    //            //"plus":
    //            plus.GetComponent<Text>().enabled = true;
    //            //"plus2":
    //            plus2.GetComponent<Text>().enabled = true;
    //            //"mult":
    //            mult.GetComponent<Text>().enabled = true;
    //            //"divide":
    //            divide.GetComponent<Text>().enabled = true;
    //            break;
    //        case 4:
    //            //"plus":
    //            plus.GetComponent<Text>().enabled = true;
    //            //"mult2":
    //            mult2.GetComponent<Text>().enabled = true;
    //            //"mult":
    //            mult.GetComponent<Text>().enabled = true;
    //            //"divide":
    //            divide.GetComponent<Text>().enabled = true;
    //            break;
    //    }
    //}

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
            //Market.resetMarket();
            SoundManager.instance.GameEnd();
            SoundManager.instance.TimeRunningOut(false);

            GameObject lossTxt = GameObject.Find("loseTxt");
            lossTxt.GetComponent<Text>().enabled = true;
            
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

        //if (Market.hasClock)
        //{
        //    countdownTimer += 10;
        //    GameObject clock = GameObject.Find("clock");
        //    clock.GetComponent<Image>().enabled = true;
        //}
        //if (Market.hasPower)
        //{
        //    GameObject power = GameObject.Find("power");
        //    power.GetComponent<Image>().enabled = true;

        //    //power.SetActive(false);
        //}
        ////resetFormula();
        //if (Market.hasClow)
        //{
        //    //showOperators();
        //    GameObject clow = GameObject.Find("Clow");
        //    clow.GetComponent<Image>().enabled = true;

        //    //clow.SetActive(false);
        //}
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
            scoreCount -= 10;
            allScore -= 10;
            scoreText.text = "Puntaje: " + scoreCount;
            scoreFillUI.fillAmount = (float)scoreCount / sumScoreInThisLvl;
            if (countdownTimer > 10)
            {
                countdownTimer -= 10;
            }
            else
            {
                StopCoroutine("Countdown");
                //Market.resetMarket();
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
            scoreText.text = "Puntaje: " + scoreCount;

            scoreFillUI.fillAmount = (float)scoreCount / sumScoreInThisLvl;


        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 7:
                if (level1 == 5) done = true;
                break;
            //case 2:
            //    if (level2 == 9) done = true;
            //    break;
            //case 3:
            //    if (level3 == 9) done = true;
            //    break;
            //case 4:
            //    if (level4 == 9) done = true;
            //    break;
            //case 5:
            //    if (level5 == 9) done = true;
            //    break;
            //case 6:
            //    if (level6 == 9) done = true;
            //    break;
        }

        

    }

    private void formula(bool show)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 7:
                sumScoreInThisLvl = 150f;
                SoundManager.instance.RopeStretch(false);
                switch (HookScript.itemValue)
                {
                    case "plus":
                        //GameObject plus = GameObject.Find("plus");
                        //plus.GetComponent<Text>().enabled = show;
                        level1++;
                        nRespuestaCorrecta = 1;
                        PreguntaBG.SetActive(true);
                        PreguntaTxt.GetComponent<Text>().text = "Pregunta:\n¿Cuál de los siguientes objetos es contaminante para un ecosistema acuático?";
                        Respuesta1Txt.GetComponent<Text>().text = "Sustancias tóxicas";
                        Respuesta2Txt.GetComponent<Text>().text = "Algas marinas";
                        Respuesta3Txt.GetComponent<Text>().text = "Rocas";
                        Respuesta4Txt.GetComponent<Text>().text = "Estrella de mar";
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                    case "four":
                        //GameObject four = GameObject.Find("four");
                        //four.GetComponent<Text>().enabled = show;
                        level1++;
                        nRespuestaCorrecta = 2;
                        PreguntaBG.SetActive(true);
                        PreguntaTxt.GetComponent<Text>().text = "Pregunta:\n¿Cuál de los siguientes seres acuáticos es un depredador?";
                        Respuesta1Txt.GetComponent<Text>().text = "Pez Payaso";
                        Respuesta2Txt.GetComponent<Text>().text = "Tiburón";
                        Respuesta3Txt.GetComponent<Text>().text = "Estrella de mar";
                        Respuesta4Txt.GetComponent<Text>().text = "Caballito de mar";
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                    case "mult":
                        //GameObject mult = GameObject.Find("mult");
                        //mult.GetComponent<Text>().enabled = show;
                        level1++;
                        nRespuestaCorrecta = 1;
                        PreguntaBG.SetActive(true);
                        PreguntaTxt.GetComponent<Text>().text = "Pregunta:\n¿Cuál de los siguientes residuos marinos NO es reciclable?";
                        Respuesta1Txt.GetComponent<Text>().text = "Sustancias químicas";
                        Respuesta2Txt.GetComponent<Text>().text = "Latas de comida";
                        Respuesta3Txt.GetComponent<Text>().text = "Botellas de vidrio y plástico";
                        Respuesta4Txt.GetComponent<Text>().text = "Bolsas de plástico";
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                    case "three":
                        //GameObject three = GameObject.Find("three");
                        //three.GetComponent<Text>().enabled = show;
                        level1++;
                        nRespuestaCorrecta = 4;
                        PreguntaBG.SetActive(true);
                        PreguntaTxt.GetComponent<Text>().text = "Pregunta:\n¿Cuál de los siguientes animales NO es vertebrado?";
                        Respuesta1Txt.GetComponent<Text>().text = "Pez Espada";
                        Respuesta2Txt.GetComponent<Text>().text = "Rana";
                        Respuesta3Txt.GetComponent<Text>().text = "Tiburón";
                        Respuesta4Txt.GetComponent<Text>().text = "Estrella de mar";
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                    case "six":
                        //GameObject six = GameObject.Find("six");
                        //six.GetComponent<Text>().enabled = show;
                        level1++;
                        nRespuestaCorrecta = 3;
                        PreguntaBG.SetActive(true);
                        PreguntaTxt.GetComponent<Text>().text = "Pregunta:\n¿Cuál de los siguientes animales acuáticos es el más grande?";
                        Respuesta1Txt.GetComponent<Text>().text = "Estrella de mar";
                        Respuesta2Txt.GetComponent<Text>().text = "Pez Espada";
                        Respuesta3Txt.GetComponent<Text>().text = "Ballena";
                        Respuesta4Txt.GetComponent<Text>().text = "Tiburón";
                        Time.timeScale = 0f;
                        GameIsPause = true;
                        break;
                }
                break;
    //        case 2:
    //            sumScoreInThisLvl = 190f;
    //            switch (HookScript.itemValue)
    //            {
    //                case "plus":
    //                    GameObject plus = GameObject.Find("plus");
    //                    plus.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "plus2":
    //                    GameObject plus2 = GameObject.Find("plus2");
    //                    plus2.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "mult":
    //                    GameObject mult = GameObject.Find("mult");
    //                    mult.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "nine":
    //                    GameObject nine = GameObject.Find("nine");
    //                    nine.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "five":
    //                    GameObject five = GameObject.Find("five");
    //                    five.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "eight":
    //                    GameObject eight = GameObject.Find("eight");
    //                    eight.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "seven":
    //                    GameObject seven = GameObject.Find("seven");
    //                    seven.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "minus":
    //                    GameObject minus = GameObject.Find("minus");
    //                    minus.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //                case "one":
    //                    GameObject one = GameObject.Find("one");
    //                    one.GetComponent<Text>().enabled = show;
    //                    level2++;
    //                    break;
    //            }
    //            break;
    //        case 3:
    //            sumScoreInThisLvl = 210f;
    //            switch (HookScript.itemValue)
    //            {
    //                case "plus":
    //                    GameObject plus = GameObject.Find("plus");
    //                    plus.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "plus2":
    //                    GameObject plus2 = GameObject.Find("plus2");
    //                    plus2.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "mult":
    //                    GameObject mult = GameObject.Find("mult");
    //                    mult.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "divide":
    //                    GameObject divide = GameObject.Find("divide");
    //                    divide.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "nine":
    //                    GameObject nine = GameObject.Find("nine");
    //                    nine.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "two":
    //                    GameObject two = GameObject.Find("two");
    //                    two.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "eight":
    //                    GameObject eight = GameObject.Find("eight");
    //                    eight.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "seven":
    //                    GameObject seven = GameObject.Find("seven");
    //                    seven.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //                case "six":
    //                    GameObject six = GameObject.Find("six");
    //                    six.GetComponent<Text>().enabled = show;
    //                    level3++;
    //                    break;
    //            }
    //            break;
    //        case 4:
    //            sumScoreInThisLvl = 230f;
    //            switch (HookScript.itemValue)
    //            {
    //                case "plus":
    //                    GameObject plus = GameObject.Find("plus");
    //                    plus.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "mult2":
    //                    GameObject mult2 = GameObject.Find("mult2");
    //                    mult2.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "mult":
    //                    GameObject mult = GameObject.Find("mult");
    //                    mult.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "divide":
    //                    GameObject divide = GameObject.Find("divide");
    //                    divide.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "nine":
    //                    GameObject nine = GameObject.Find("nine");
    //                    nine.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "two":
    //                    GameObject two = GameObject.Find("two");
    //                    two.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "nine2":
    //                    GameObject nine2 = GameObject.Find("nine2");
    //                    nine2.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "seven":
    //                    GameObject seven = GameObject.Find("seven");
    //                    seven.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //                case "five":
    //                    GameObject five = GameObject.Find("five");
    //                    five.GetComponent<Text>().enabled = show;
    //                    level4++;
    //                    break;
    //            }
    //            break;

        }
    }
    //void resetFormula()
    //{
    //    GameObject plus = GameObject.Find("plus");
    //    GameObject plus2 = GameObject.Find("plus2");
    //    GameObject minus = GameObject.Find("minus");
    //    GameObject mult = GameObject.Find("mult");
    //    GameObject divide = GameObject.Find("divide");
    //    GameObject one = GameObject.Find("one");
    //    GameObject two = GameObject.Find("two");
    //    GameObject three = GameObject.Find("three");
    //    GameObject four = GameObject.Find("four");
    //    GameObject five = GameObject.Find("five");
    //    GameObject six = GameObject.Find("six");
    //    GameObject seven = GameObject.Find("seven");
    //    GameObject eight = GameObject.Find("eight");
    //    GameObject nine = GameObject.Find("nine");
    //    GameObject mult2 = GameObject.Find("mult2");
    //    GameObject nine2 = GameObject.Find("nine2");
    //    switch (SceneManager.GetActiveScene().buildIndex)
    //    {
    //        case 1:
    //            plus.GetComponent<Text>().enabled = false;
    //            four.GetComponent<Text>().enabled = false;
    //            mult.GetComponent<Text>().enabled = false;
    //            three.GetComponent<Text>().enabled = false;
    //            six.GetComponent<Text>().enabled = false;
    //            break;
    //        case 2:
    //            plus.GetComponent<Text>().enabled = false;
    //            plus2.GetComponent<Text>().enabled = false;
    //            mult.GetComponent<Text>().enabled = false;
    //            nine.GetComponent<Text>().enabled = false;
    //            five.GetComponent<Text>().enabled = false;
    //            eight.GetComponent<Text>().enabled = false;
    //            seven.GetComponent<Text>().enabled = false;
    //            minus.GetComponent<Text>().enabled = false;
    //            one.GetComponent<Text>().enabled = false;
    //            break;
    //        case 3:
    //            plus.GetComponent<Text>().enabled = false;
    //            plus2.GetComponent<Text>().enabled = false;
    //            mult.GetComponent<Text>().enabled = false;
    //            divide.GetComponent<Text>().enabled = false;
    //            nine.GetComponent<Text>().enabled = false;
    //            two.GetComponent<Text>().enabled = false;
    //            eight.GetComponent<Text>().enabled = false;
    //            seven.GetComponent<Text>().enabled = false;
    //            six.GetComponent<Text>().enabled = false;
    //            break;
    //        case 4:
    //            plus.GetComponent<Text>().enabled = false;
    //            mult2.GetComponent<Text>().enabled = false;
    //            mult.GetComponent<Text>().enabled = false;
    //            divide.GetComponent<Text>().enabled = false;
    //            nine.GetComponent<Text>().enabled = false;
    //            two.GetComponent<Text>().enabled = false;
    //            nine2.GetComponent<Text>().enabled = false;
    //            seven.GetComponent<Text>().enabled = false;
    //            five.GetComponent<Text>().enabled = false;
    //            break;
    //    }
    //}
    // הפעלת המשחק מחדש ובהמשך הפעלת שלב הבא

    public void Resume(int itemTag)
    {
        if (itemTag == nRespuestaCorrecta) {
            scoreCount += 20;
            allScore += 20;
            scoreText.text = "Puntaje: " + scoreCount;

            scoreFillUI.fillAmount = (float)scoreCount / sumScoreInThisLvl;
        }
        PreguntaBG.SetActive(false);
        if (done)
        {
            StopCoroutine("Countdown");
            SoundManager.instance.GameEnd();
            success = true;
            //Market.resetMarket();
            //levelReached += 1;
            GameObject winTxt = GameObject.Find("winTxt");
            winTxt.GetComponent<Text>().enabled = true;
            continuarButton.SetActive(true);
            //StartCoroutine(RestartGame(1182));
            //SceneManager.LoadScene(1);
        }
        else
        {
            Time.timeScale = 1f;
            GameIsPause = false;
        }

    }

    public void Continuar()
    {
        LevelSelectLake.lvl1Superado = true;
        PuntajeLvl1 = scoreCount;
        Time.timeScale = 1f;
        GameIsPause = false;
        SceneManager.LoadScene(14);
    }

    IEnumerator RestartGame(int scene)
    {
        yield return new WaitForSeconds(4f);
        //if (success) levelReached++;
        SceneManager.LoadScene(14);
    }

} // class
