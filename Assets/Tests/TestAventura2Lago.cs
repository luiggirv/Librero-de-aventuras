using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.EventSystems;
using UnityEditor;

public class TestAventura2Lago
{
    [SetUp]
    public void Setup()
    {

    }


    [UnityTest]
    public IEnumerator TestAventura2LagoTimeGlobal()
    {
        //Se crea un objeto con clase GameplayManager
        var gameplayManager = new GameObject();
        gameplayManager.AddComponent<GameplayManager>();
        var preguntaBG = new GameObject();
        var preguntaTxt = new GameObject();
        preguntaTxt.AddComponent<Text>();
        var respuesta1 = new GameObject();
        respuesta1.AddComponent<Text>();
        var respuesta2 = new GameObject();
        respuesta2.AddComponent<Text>();
        var respuesta3 = new GameObject();
        respuesta3.AddComponent<Text>();
        var respuesta4 = new GameObject();
        respuesta4.AddComponent<Text>();
        var continuarButton = new GameObject();
        continuarButton.AddComponent<Button>();
        var correctSound = new GameObject();
        correctSound.AddComponent<AudioSource>();
        var wrongSound = new GameObject();
        wrongSound.AddComponent<AudioSource>();
        var timeText = new GameObject();
        timeText.AddComponent<Text>();
        var winTxt = new GameObject();
        winTxt.AddComponent<Text>();
        winTxt.name = "winTxt";
        var loseTxt = new GameObject();
        loseTxt.AddComponent<Text>();
        loseTxt.name = "loseTxt";

        //Se inicializan los parametros de la clase GameplayManager
        gameplayManager.GetComponent<GameplayManager>().countdownText = timeText.GetComponent<Text>();
        gameplayManager.GetComponent<GameplayManager>().countdownTimer = 120;
        gameplayManager.GetComponent<GameplayManager>().nRespuestaCorrecta = 0;
        gameplayManager.GetComponent<GameplayManager>().PreguntaBG = preguntaBG;
        gameplayManager.GetComponent<GameplayManager>().PreguntaTxt = preguntaTxt;
        gameplayManager.GetComponent<GameplayManager>().Respuesta1Txt = respuesta1;
        gameplayManager.GetComponent<GameplayManager>().Respuesta2Txt = respuesta2;
        gameplayManager.GetComponent<GameplayManager>().Respuesta3Txt = respuesta3;
        gameplayManager.GetComponent<GameplayManager>().Respuesta4Txt = respuesta4;
        gameplayManager.GetComponent<GameplayManager>().continuarButton = continuarButton;
        gameplayManager.GetComponent<GameplayManager>().correctSound = correctSound.GetComponent<AudioSource>();
        gameplayManager.GetComponent<GameplayManager>().wrongSound = wrongSound.GetComponent<AudioSource>();
        gameplayManager.GetComponent<GameplayManager>().preguntasSonAcuaticas = true;
        gameplayManager.GetComponent<GameplayManager>().preguntasSonReciclaje = false;

        //Se captura el valor actual del tiempo, se espera 5 segundos y se evalua si el tiempo disminuyó
        var oldTime = gameplayManager.GetComponent<GameplayManager>().countdownTimer;
        yield return new WaitForSeconds(5);
        Assert.IsTrue(oldTime > gameplayManager.GetComponent<GameplayManager>().countdownTimer);

        //Se crea la clase PauseMenuLago
        var pauseMenu = new GameObject();
        pauseMenu.AddComponent<PauseMenuLago>();
        var pauseMenuUI = new GameObject();

        //Se inicializan los parametros de la clase PauseMenuLago
        pauseMenu.GetComponent<PauseMenuLago>().pauseMenuUI = pauseMenuUI;

        //Pausar el tiempo
        pauseMenu.GetComponent<PauseMenuLago>().Pause();
        Assert.IsTrue(pauseMenu.GetComponent<PauseMenuLago>().isPause()); // Se evalua si está en pausa

        //Reanudar el tiempo
        pauseMenu.GetComponent<PauseMenuLago>().Resume();
        var newTime = gameplayManager.GetComponent<GameplayManager>().countdownTimer; //Se captura el tiempo actual
        yield return new WaitForSeconds(5); //Se espera 5 segundos para evaluar si el tiempo cambia cuando está pausado
        Assert.IsTrue(newTime > gameplayManager.GetComponent<GameplayManager>().countdownTimer); // Se evalua si el tiempo disminuyó

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAventura2LagoScoreGlobal()
    {
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {

    }


}
