using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.EventSystems;
using UnityEditor;

public class TestAventura2Bosque
{
    [SetUp]
    public void Setup()
    {

    }


    [UnityTest]
    public IEnumerator TestAventura2BosqueHealthSystem()
    {

        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAventura2BosqueTimeGlobal()
    {
        //Se crea el componente Artifact para que aparezca en el escenario
        var corral = new Artifact();
        var audioSource = new GameObject();
        var sonidoCorral = new GameObject();
        var player = new GameObject();

        //Se inicializan los parametros del componente Artifact
        corral.health = 120;
        corral.maxHealth = 120;
        corral.bleed = 0;
        corral.audioSource = audioSource;
        corral.sonidoCorral = sonidoCorral;
        corral.player = player;

        //Se crea un GameObject que contenga el compontente Manager
        var manager = new GameObject();
        manager.AddComponent<Manager>();
        var gameOverUI = new GameObject();
        var puntajeFinalText = new GameObject();
        puntajeFinalText.AddComponent<Text>();

        //Se inicializan los parametros del componente Manager con tiempo inicial 60 segundos
        manager.GetComponent<Manager>().timeToWin = 60.0f;
        manager.GetComponent<Manager>().gameOverUI = gameOverUI;
        manager.GetComponent<Manager>().PuntajeFinalText = puntajeFinalText;
        manager.GetComponent<Manager>().artifact = corral;

        Debug.Log(manager.GetComponent<Manager>().GetTime());
        //Se crea el componente PauseMenuEcosistema para que aparezca en el escenario
        var pauseMenu = new GameObject();
        pauseMenu.AddComponent<PauseMenuEcosistema>();
        var pauseMenuUI = new GameObject();

        //Se inicializan los parametros del componente PauseMenuEcosistema
        pauseMenu.GetComponent<PauseMenuEcosistema>().pauseMenuUI = pauseMenuUI;

        //Pausar el tiempo
        var oldTime = manager.GetComponent<Manager>().GetTime(); //Se captura el tiempo actual
        pauseMenu.GetComponent<PauseMenuEcosistema>().Pause();
        Assert.AreEqual(oldTime, manager.GetComponent<Manager>().GetTime()); // Se evalua si los valores son iguales

        //Reanudar el tiempo
        pauseMenu.GetComponent<PauseMenuEcosistema>().Resume();

        var newTime = manager.GetComponent<Manager>().GetTime(); //Se captura el tiempo actual
        yield return new WaitForSeconds(5); //Se espera 5 segundos para evaluar si el tiempo cambia cuando está pausado
        Assert.AreNotEqual(newTime, manager.GetComponent<Manager>().GetTime()); // Se evalua si los valores no son iguales

        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAventura2BosqueScoreGlobal()
    {
        //Se crea el componente Artifact para que aparezca en el escenario
        var corral = new GameObject();
        corral.AddComponent<Artifact>();
        var audioSource = new GameObject();
        audioSource.AddComponent<AudioSource>();
        var sonidoCorral = new GameObject();
        sonidoCorral.AddComponent<AudioSource>();
        var player = new GameObject();
        player.AddComponent<PlayerBackpack>();

        //Se inicializan los parametros del componente Artifact
        corral.GetComponent<Artifact>().health = 120;
        corral.GetComponent<Artifact>().maxHealth = 120;
        corral.GetComponent<Artifact>().bleed = 0;
        corral.GetComponent<Artifact>().audioSource = audioSource;
        corral.GetComponent<Artifact>().sonidoCorral = sonidoCorral;
        player.GetComponent<PlayerBackpack>().max = 50; //Max capacidad de frutas en la mochila
        player.GetComponent<PlayerBackpack>().current = 40; //Número de frutas actualmente
        corral.GetComponent<Artifact>().player = player;
        corral.gameObject.tag = "Artifact";

        //Se crea un GameObject que contenga el compontente Manager
        var manager = new GameObject();
        manager.AddComponent<Manager>();
        var gameOverUI = new GameObject();
        var puntajeFinalText = new GameObject();
        puntajeFinalText.AddComponent<Text>();

        //Se inicializan los parametros del componente Manager con tiempo inicial 60 segundos
        manager.GetComponent<Manager>().timeToWin = 60.0f;
        manager.GetComponent<Manager>().gameOverUI = gameOverUI;
        manager.GetComponent<Manager>().PuntajeFinalText = puntajeFinalText;
        manager.GetComponent<Manager>().artifact = corral.GetComponent<Artifact>();

        //Se crea un GameObject que contenga el compontente ScoreGlobalTower
        var scoreGlobal = new GameObject();
        scoreGlobal.AddComponent<ScoreGlobalTower>();
        var puntajeText = new GameObject();
        puntajeText.AddComponent<Text>();

        //Se inicializan los parametros del componente ScoreGlobalTower
        scoreGlobal.GetComponent<ScoreGlobalTower>().PuntajeReal = puntajeText;
        scoreGlobal.GetComponent<ScoreGlobalTower>().InternalScore = 0;

        //Se analiza si el puntaje aumenta automáticamente (1 segundo = +100 puntos)
        yield return new WaitForSeconds(5); //Esperamos 5 segundos para ver si el puntaje aumenta
        Assert.IsTrue((scoreGlobal.GetComponent<ScoreGlobalTower>().InternalScore)*100 == 500); 
        //El score debería ser 500

        //Se da la comida al corral para aumentar el puntaje. (Puntaje actual = 500)
        corral.GetComponent<Artifact>().eatFruit(); //La mochila tiene 40 frutas y cada fruta da 100 puntos. 
        yield return new WaitForSeconds(1); //Se aumenta 100 puntos por el segundo esperado
        Assert.IsTrue(scoreGlobal.GetComponent<ScoreGlobalTower>().InternalScore*100 == (500 + 4000 + 100));
        //El puntaje total debería ser 4600 puntos.

        var animal = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/TowerDefense/Prefabs/wolf3.prefab");
        animal = GameObject.Instantiate(animal, new Vector3(0, 0, 10), new Quaternion(0, 180, 0, 0));

        //Esperamos que el animal ataque al corral.
        //Se demora 2 segundos en llegar al corrar. Al tercer segundo, empieza a atacar
        yield return new WaitForSeconds(5); //El animal atacó por 3 segundos. 1 segundo = -100 score
        //De 4600 en total, debió bajar a 4300 de puntaje
        Assert.IsTrue(scoreGlobal.GetComponent<ScoreGlobalTower>().InternalScore * 100 == 4300);
        // Use yield to skip a frame.
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {

    }


}
