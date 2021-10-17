using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.EventSystems;
using UnityEditor;

public class TestAventura2Montaña
{
    [SetUp]
    public void Setup()
    {

    }


    [UnityTest]
    public IEnumerator TestAventura2MontañaTimeGlobal()
    {

        //Se crea un objeto con clase GameController
        var manager = new GameObject();
        manager.AddComponent<GameController>();
        var camera = new GameObject();
        camera.AddComponent<Camera>();
        var objects = new GameObject[10];
        var timeText = new GameObject();
        timeText.AddComponent<Text>();
        var gameoverUI = new GameObject();
        var restartButton = new GameObject();
        var splashScreen = new GameObject();
        var startButton = new GameObject();
        var lluvioso = new GameObject();
        var soleado = new GameObject();
        var nevoso = new GameObject();
        var tormenta = new GameObject();
        var happymusic = new GameObject();
        happymusic.AddComponent<AudioSource>();
        var stormmusic = new GameObject();
        stormmusic.AddComponent<AudioSource>();
        var rainmusic = new GameObject();
        rainmusic.AddComponent<AudioSource>();
        var instruccionesNevoso = new GameObject();
        var instruccionesTormenta = new GameObject();
        var instruccionesLluvioso = new GameObject();

        //Se crea un objeto con clase HatController
        var hat = new GameObject();
        hat.AddComponent<HatController>();
        hat.AddComponent<SpriteRenderer>();
        hat.AddComponent<Rigidbody2D>();

        //Se inicializan los parametros de la clase HatController
        hat.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/CatchGame/bucket.png"); 
        hat.GetComponent<HatController>().cam = camera.GetComponent<Camera>();

        //Se inicializan los parametros de la clase GameController
        var objeto = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[0] = objeto;
        var objeto2 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/WaterDrop.prefab");
        objects[1] = objeto2;
        var objeto3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/WaterDrop.prefab");
        objects[2] = objeto3;
        var objeto4 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/WaterDrop.prefab");
        objects[3] = objeto4;
        var objeto5 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Rama.prefab");
        objects[4] = objeto5;
        var objeto6 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Rama.prefab");
        objects[5] = objeto6;
        var objeto7 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Rama.prefab");
        objects[6] = objeto7;
        var objeto8 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[7] = objeto8;
        var objeto9 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[8] = objeto9;
        var objeto10 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[9] = objeto10;

        manager.GetComponent<GameController>().balls = objects;
        manager.GetComponent<GameController>().cam = camera.GetComponent<Camera>();
        manager.GetComponent<GameController>().timeLeft = 60; // Tiempo del nivel
        manager.GetComponent<GameController>().timerText = timeText.GetComponent<Text>();
        manager.GetComponent<GameController>().gameOverText = gameoverUI;
        manager.GetComponent<GameController>().restartButton = restartButton;
        manager.GetComponent<GameController>().splashScreen = splashScreen;
        manager.GetComponent<GameController>().startButton = startButton;
        manager.GetComponent<GameController>().hat_Controller = hat.GetComponent<HatController>();
        manager.GetComponent<GameController>().numberSpawn = 4;
        manager.GetComponent<GameController>().lluvioso = lluvioso;
        manager.GetComponent<GameController>().soleado = soleado;
        manager.GetComponent<GameController>().nevoso = nevoso;
        manager.GetComponent<GameController>().tormenta = tormenta;
        manager.GetComponent<GameController>().happyMusic = happymusic;
        manager.GetComponent<GameController>().stormMusic = stormmusic;
        manager.GetComponent<GameController>().rainMusic = rainmusic;
        manager.GetComponent<GameController>().instructionsNevoso = instruccionesNevoso;
        manager.GetComponent<GameController>().instructionsTormenta = instruccionesTormenta;
        manager.GetComponent<GameController>().instructionsLluvioso = instruccionesLluvioso;

        yield return new WaitForSeconds(1);

        //Se inicia el minijuego
        manager.GetComponent<GameController>().StartGame();

        //Se crea la clase PauseMenuCatch
        var pauseMenu = new GameObject();
        pauseMenu.AddComponent<PauseMenuCatch>();
        var pauseMenuUI = new GameObject();

        //Se inicializan los parametros de la clase PauseMenuCatch
        pauseMenu.GetComponent<PauseMenuCatch>().pauseMenuUI = pauseMenuUI;

        //Pausar el tiempo
        pauseMenu.GetComponent<PauseMenuCatch>().Pause();
        Assert.IsTrue(pauseMenu.GetComponent<PauseMenuCatch>().isPause()); // Se evalua si está en pausa

        //Reanudar el tiempo
        pauseMenu.GetComponent<PauseMenuCatch>().Resume();
        var oldTime = manager.GetComponent<GameController>().timeLeft;
        yield return new WaitForSeconds(5); //Se espera 5 segundos para evaluar si el tiempo cambia
        Assert.IsTrue(oldTime > manager.GetComponent<GameController>().timeLeft); // Se evalua si el tiempo disminuyó


        yield return null;
    }

        [UnityTest]
    public IEnumerator TestAventura2MontañaScoreGlobal()
    {
        //Se crea un objeto con clase GameController
        var manager = new GameObject();
        manager.AddComponent<GameController>();
        var camera = new GameObject();
        camera.AddComponent<Camera>();
        var objects = new GameObject[10];
        var timeText = new GameObject();
        timeText.AddComponent<Text>();
        var gameoverUI = new GameObject();
        var restartButton = new GameObject();
        var splashScreen = new GameObject();
        var startButton = new GameObject();
        var lluvioso = new GameObject();
        var soleado = new GameObject();
        var nevoso = new GameObject();
        var tormenta = new GameObject();
        var happymusic = new GameObject();
        happymusic.AddComponent<AudioSource>();
        var stormmusic = new GameObject();
        stormmusic.AddComponent<AudioSource>();
        var rainmusic = new GameObject();
        rainmusic.AddComponent<AudioSource>();
        var instruccionesNevoso = new GameObject();
        var instruccionesTormenta = new GameObject();
        var instruccionesLluvioso = new GameObject();

        //Se crea un objeto con clase HatController
        var hat = new GameObject();
        hat.AddComponent<HatController>();
        hat.AddComponent<SpriteRenderer>();
        hat.AddComponent<Rigidbody2D>();
        hat.AddComponent<Score>();
        var scoreText = new GameObject();
        scoreText.AddComponent<Text>();
        var splashSound = new GameObject();
        splashSound.AddComponent<AudioSource>();
        var wrongSound = new GameObject();
        wrongSound.AddComponent<AudioSource>();


        //Se inicializan los parametros de la clase HatController
        hat.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/CatchGame/bucket.png");
        hat.GetComponent<HatController>().cam = camera.GetComponent<Camera>();
        hat.GetComponent<Score>().scoreText = scoreText.GetComponent<Text>();
        hat.GetComponent<Score>().ballValue = 100;
        hat.GetComponent<Score>().splash = splashSound.GetComponent<AudioSource>();
        hat.GetComponent<Score>().wrongSound = wrongSound.GetComponent<AudioSource>();

        //Se inicializan los parametros de la clase GameController
        var objeto = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[0] = objeto;
        var objeto2 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/WaterDrop.prefab");
        objects[1] = objeto2;
        var objeto3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/WaterDrop.prefab");
        objects[2] = objeto3;
        var objeto4 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/WaterDrop.prefab");
        objects[3] = objeto4;
        var objeto5 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Rama.prefab");
        objects[4] = objeto5;
        var objeto6 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Rama.prefab");
        objects[5] = objeto6;
        var objeto7 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Rama.prefab");
        objects[6] = objeto7;
        var objeto8 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[7] = objeto8;
        var objeto9 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[8] = objeto9;
        var objeto10 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Prefabs/Hoja.prefab");
        objects[9] = objeto10;

        manager.GetComponent<GameController>().balls = objects;
        manager.GetComponent<GameController>().cam = camera.GetComponent<Camera>();
        manager.GetComponent<GameController>().timeLeft = 60; // Tiempo del nivel
        manager.GetComponent<GameController>().timerText = timeText.GetComponent<Text>();
        manager.GetComponent<GameController>().gameOverText = gameoverUI;
        manager.GetComponent<GameController>().restartButton = restartButton;
        manager.GetComponent<GameController>().splashScreen = splashScreen;
        manager.GetComponent<GameController>().startButton = startButton;
        manager.GetComponent<GameController>().hat_Controller = hat.GetComponent<HatController>();
        manager.GetComponent<GameController>().numberSpawn = 4;
        manager.GetComponent<GameController>().lluvioso = lluvioso;
        manager.GetComponent<GameController>().soleado = soleado;
        manager.GetComponent<GameController>().nevoso = nevoso;
        manager.GetComponent<GameController>().tormenta = tormenta;
        manager.GetComponent<GameController>().happyMusic = happymusic;
        manager.GetComponent<GameController>().stormMusic = stormmusic;
        manager.GetComponent<GameController>().rainMusic = rainmusic;
        manager.GetComponent<GameController>().instructionsNevoso = instruccionesNevoso;
        manager.GetComponent<GameController>().instructionsTormenta = instruccionesTormenta;
        manager.GetComponent<GameController>().instructionsLluvioso = instruccionesLluvioso;

        yield return new WaitForSeconds(1);

        //Se inicia el minijuego
        manager.GetComponent<GameController>().StartGame();

        //Se añade puntaje 
        hat.GetComponent<Score>().addScore(); //Por cada llamada aumenta en +100 el puntaje
        hat.GetComponent<Score>().addScore();
        hat.GetComponent<Score>().addScore();
        yield return new WaitForSeconds(1); // Se espera 1 segundo para que termine la operación
        Assert.IsTrue(hat.GetComponent<Score>().showScore() == 300);

        //Se resta puntaje 
        hat.GetComponent<Score>().subtractScore(); //Por cada llamada, disminuye en 200 el puntaje
        yield return new WaitForSeconds(1); // Se espera 1 segundo para que termine la operación
        Assert.IsTrue(hat.GetComponent<Score>().showScore() == 100);

        //Verificar que el puntaje no pueda ser negativo
        hat.GetComponent<Score>().subtractScore(); //Por cada llamada, disminuye en 200 el puntaje
        yield return new WaitForSeconds(1); // Se espera 1 segundo para que termine la operación
        Assert.IsTrue(hat.GetComponent<Score>().showScore() == 0);

        yield return null;
    }

    [TearDown]
    public void TearDown()
    {

    }


}
