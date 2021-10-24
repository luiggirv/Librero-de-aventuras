using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.EventSystems;
using UnityEditor;

public class TestAventura3
{
    [SetUp]
    public void Setup()
    {

    }


    [UnityTest]
    public IEnumerator TestAventura3GoalManager()
    {
        //Se crea un objeto con clase GUIManager
        var GUIManagerObject = new GameObject();
        GUIManagerObject.AddComponent<GUIManager>();
        var overlay = new GameObject();
        overlay.AddComponent<SpriteRenderer>();
        var pauseText = new GameObject();
        pauseText.AddComponent<Text>();
        var buttonText = new GameObject();
        buttonText.AddComponent<Text>();
        var playButton = new GameObject();
        var pauseButton = new GameObject();
        var toolbox = new GameObject();
        var pauseMenu = new GameObject();
        var finishMenu = new GameObject();

        var markers = new Transform[4];
        var marker1 = new GameObject();
        marker1.AddComponent<SpriteRenderer>();
        var marker2 = new GameObject();
        marker2.AddComponent<SpriteRenderer>();
        var marker3 = new GameObject();
        marker3.AddComponent<SpriteRenderer>();
        var marker4 = new GameObject();
        marker4.AddComponent<SpriteRenderer>();

        marker1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[0] = marker1.transform;
        marker2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[1] = marker2.transform;
        marker3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[2] = marker3.transform;
        marker4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[3] = marker4.transform;

        //Se inicializa el objeto GUIManagerObject
        GUIManagerObject.GetComponent<GUIManager>().overlay = overlay.GetComponent<SpriteRenderer>();
        GUIManagerObject.GetComponent<GUIManager>().pausaText = pauseText;
        GUIManagerObject.GetComponent<GUIManager>().pausaText = buttonText;
        GUIManagerObject.GetComponent<GUIManager>().playButton = playButton.transform;
        GUIManagerObject.GetComponent<GUIManager>().pauseButton = pauseButton.transform;
        GUIManagerObject.GetComponent<GUIManager>().toolbox = toolbox.transform;
        GUIManagerObject.GetComponent<GUIManager>().pauseMenu = pauseMenu.transform;
        GUIManagerObject.GetComponent<GUIManager>().finishMenu = finishMenu.transform;
        GUIManagerObject.GetComponent<GUIManager>().markers = markers;

        //Se crea un objeto con clase ToolboxManager
        var toolboxManagerObject = new GameObject();
        toolboxManagerObject.AddComponent<ToolboxManager>();
        var button = new GameObject();
        var strip = new GameObject();
        var itemContainer = new GameObject();
        var tempContainer = new GameObject();

        //Se inicializa el objeto toolboxManagerObject
        button.AddComponent<SpriteRenderer>();
        button.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/CatchGame/bucket.png");

        toolboxManagerObject.GetComponent<ToolboxManager>().maxToolboxMovement = 7.75f;
        toolboxManagerObject.GetComponent<ToolboxManager>().spaceBetweenItems = 0.15f;
        toolboxManagerObject.GetComponent<ToolboxManager>().button = button.transform;
        toolboxManagerObject.GetComponent<ToolboxManager>().strip = strip.transform;
        toolboxManagerObject.GetComponent<ToolboxManager>().itemContainer = itemContainer.transform;
        toolboxManagerObject.GetComponent<ToolboxManager>().tempContainer = tempContainer.transform;

        //Se crea un objeto con clase LevelManager
        var levelManagerObject = new GameObject();
        levelManagerObject.AddComponent<LevelManager>();
        var activecontainer = new GameObject();
        var toolboxcontainer = new GameObject();

        //Se inicializa el objeto levelManagerObject
        var globoToolbox = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Toolbox/BalloonToolbox.prefab");
        var globoTool = GameObject.Instantiate(globoToolbox, Vector3.zero, Quaternion.identity);
        globoTool.transform.parent = toolboxcontainer.transform;

        levelManagerObject.GetComponent<LevelManager>().levelNumber = "21";
        levelManagerObject.GetComponent<LevelManager>().activeContainer = activecontainer.transform;
        levelManagerObject.GetComponent<LevelManager>().toolboxContainer = toolboxcontainer.transform;

        yield return new WaitForSeconds(1);

        //Se crea un objeto con clase GoalManager
        var goalManagerObject = new GameObject();
        goalManagerObject.AddComponent<GoalManager>();
        var globo = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/Balloon.prefab");
        var goalBasket = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/GoalBasket.prefab");
        var basketball = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/Basketball.prefab");
        var maceta = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/Maceta.prefab");



        //Se evalua el primer caso: La meta es que un objeto (basketball) choque con otro (maceta)
        goalManagerObject.GetComponent<GoalManager>().target = basketball;
        goalManagerObject.GetComponent<GoalManager>().goal = maceta;
        goalManagerObject.GetComponent<GoalManager>().onTrigger = false;

        goalManagerObject.GetComponent<GoalManager>().CollisionEvent(basketball, maceta);
        yield return new WaitForSeconds(1); //Se espera 1 segundo para esperar que termine el nivel.

        Assert.IsTrue(levelManagerObject.GetComponent<LevelManager>().isGoalReached()); //Se evalua si el objetivo se cumplió

        levelManagerObject.GetComponent<LevelManager>().RestartFromFinish(); //Se reinicia el nivel para intentar otro caso

        //Se evalua el segundo caso: La meta es que un objeto (basketball) esté dentro de otro (goalbasket)
        goalManagerObject.GetComponent<GoalManager>().target = basketball;
        goalManagerObject.GetComponent<GoalManager>().goal = goalBasket;
        goalManagerObject.GetComponent<GoalManager>().onTrigger = true;

        goalManagerObject.GetComponent<GoalManager>().TriggerEvent(basketball, goalBasket);
        yield return new WaitForSeconds(1); //Se espera 1 segundo para esperar que termine el nivel.

        Assert.IsTrue(levelManagerObject.GetComponent<LevelManager>().isGoalReached()); //Se evalua si el objetivo se cumplió

        levelManagerObject.GetComponent<LevelManager>().RestartFromFinish(); //Se reinicia el nivel para intentar otro caso

        //Se evalua el tercer caso: La meta es que un objeto explote (globo)
        goalManagerObject.GetComponent<GoalManager>().target = globo;
        goalManagerObject.GetComponent<GoalManager>().goal = null;
        goalManagerObject.GetComponent<GoalManager>().onTrigger = false;

        goalManagerObject.GetComponent<GoalManager>().BalloonExloded(globo);
        yield return new WaitForSeconds(1); //Se espera 1 segundo para esperar que termine el nivel.

        Assert.IsTrue(levelManagerObject.GetComponent<LevelManager>().isGoalReached()); //Se evalua si el objetivo se cumplió

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestAventura3GUIManager()
    {

        //Se crea un objeto con clase GUIManager
        var GUIManagerObject = new GameObject();
        GUIManagerObject.AddComponent<GUIManager>();
        var overlay = new GameObject();
        overlay.AddComponent<SpriteRenderer>();
        var pauseText = new GameObject();
        pauseText.AddComponent<Text>();
        var buttonText = new GameObject();
        buttonText.AddComponent<Text>();
        var Play = new GameObject();
        Play.name = "Play";
        Play.AddComponent<SpriteRenderer>();
        var Pause = new GameObject();
        Pause.name = "Pause";
        Pause.AddComponent<SpriteRenderer>();
        var toolbox = new GameObject();
        var pauseMenu = new GameObject();
        var finishMenu = new GameObject();

        var markers = new Transform[4];
        var marker1 = new GameObject();
        marker1.AddComponent<SpriteRenderer>();
        var marker2 = new GameObject();
        marker2.AddComponent<SpriteRenderer>();
        var marker3 = new GameObject();
        marker3.AddComponent<SpriteRenderer>();
        var marker4 = new GameObject();
        marker4.AddComponent<SpriteRenderer>();

        var textures = new Sprite[2];
        var texture1 = new GameObject();
        texture1.AddComponent<SpriteRenderer>();
        var texture2 = new GameObject();
        texture2.AddComponent<SpriteRenderer>();

        marker1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[0] = marker1.transform;
        marker2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[1] = marker2.transform;
        marker3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[2] = marker3.transform;
        marker4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/Check.png");
        markers[3] = marker4.transform;

        Play.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/buttonsWood.png");
        Pause.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/buttonsWood.png");

        texture1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/buttonsWood.png");
        textures[0] = texture1.GetComponent<SpriteRenderer>().sprite;
        texture2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/buttonsWood.png");
        textures[1] = texture2.GetComponent<SpriteRenderer>().sprite;

        //Se inicializa el objeto GUIManagerObject
        GUIManagerObject.GetComponent<GUIManager>().overlay = overlay.GetComponent<SpriteRenderer>();
        GUIManagerObject.GetComponent<GUIManager>().pausaText = pauseText;
        GUIManagerObject.GetComponent<GUIManager>().buttonTextFinish = buttonText;
        GUIManagerObject.GetComponent<GUIManager>().playButton = Play.transform;
        GUIManagerObject.GetComponent<GUIManager>().pauseButton = Pause.transform;
        GUIManagerObject.GetComponent<GUIManager>().toolbox = toolbox.transform;
        GUIManagerObject.GetComponent<GUIManager>().pauseMenu = pauseMenu.transform;
        GUIManagerObject.GetComponent<GUIManager>().finishMenu = finishMenu.transform;
        GUIManagerObject.GetComponent<GUIManager>().markers = markers;
        GUIManagerObject.GetComponent<GUIManager>().playButtonTextures = textures;

        //Se crea un objeto con clase ToolboxManager
        var toolboxManagerObject = new GameObject();
        toolboxManagerObject.AddComponent<ToolboxManager>();
        var button = new GameObject();
        var strip = new GameObject();
        var itemContainer = new GameObject();
        var tempContainer = new GameObject();

        //Se inicializa el objeto toolboxManagerObject
        button.AddComponent<SpriteRenderer>();
        button.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Assets/Sprites/CatchGame/bucket.png");

        toolboxManagerObject.GetComponent<ToolboxManager>().maxToolboxMovement = 7.75f;
        toolboxManagerObject.GetComponent<ToolboxManager>().spaceBetweenItems = 0.15f;
        toolboxManagerObject.GetComponent<ToolboxManager>().button = button.transform;
        toolboxManagerObject.GetComponent<ToolboxManager>().strip = strip.transform;
        toolboxManagerObject.GetComponent<ToolboxManager>().itemContainer = itemContainer.transform;
        toolboxManagerObject.GetComponent<ToolboxManager>().tempContainer = tempContainer.transform;

        //Se crea un objeto con clase LevelManager
        var levelManagerObject = new GameObject();
        levelManagerObject.AddComponent<LevelManager>();
        var activecontainer = new GameObject();
        var toolboxcontainer = new GameObject();

        //Se inicializa el objeto levelManagerObject
        var globoToolbox = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Toolbox/BalloonToolbox.prefab");
        var globoTool = GameObject.Instantiate(globoToolbox, Vector3.zero, Quaternion.identity);
        globoTool.transform.parent = toolboxcontainer.transform;

        levelManagerObject.GetComponent<LevelManager>().levelNumber = "21";
        levelManagerObject.GetComponent<LevelManager>().activeContainer = activecontainer.transform;
        levelManagerObject.GetComponent<LevelManager>().toolboxContainer = toolboxcontainer.transform;

        yield return new WaitForSeconds(1);

        //Se crea un objeto con clase GoalManager
        var goalManagerObject = new GameObject();
        goalManagerObject.AddComponent<GoalManager>();
        var globo = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/Balloon.prefab");
        var goalBasket = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/GoalBasket.prefab");
        var basketball = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/Basketball.prefab");
        var maceta = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Importaciones/2D Physics Puzzle Kit/Prefabs/C#/Normal/Maceta.prefab");


        //Se inicializa la clase GoalManager
        goalManagerObject.GetComponent<GoalManager>().target = basketball;
        goalManagerObject.GetComponent<GoalManager>().goal = maceta;
        goalManagerObject.GetComponent<GoalManager>().onTrigger = false;

        //Se evalua si el nivel puede pasar a Play Mode
        GUIManagerObject.GetComponent<GUIManager>().ReceiveInput(Play.transform);
        yield return new WaitForSeconds(1);
        Assert.IsTrue(levelManagerObject.GetComponent<LevelManager>().InPlayMode()); //Se evalua si el nivel está en Play mode

        //Se evalua si el nivel puede pasar a Edit Mode despues de estar en Play Mode
        GUIManagerObject.GetComponent<GUIManager>().ReceiveInput(Play.transform);
        yield return new WaitForSeconds(1);
        Assert.IsFalse(levelManagerObject.GetComponent<LevelManager>().InPlayMode()); //Se evalua si el nivel está en Edit mode

        //Se evalua si el nivel está en Pause Mode
        GUIManagerObject.GetComponent<GUIManager>().ReceiveInput(Pause.transform);
        yield return new WaitForSeconds(1);
        Assert.IsFalse(levelManagerObject.GetComponent<LevelManager>().InPlayMode()); //Se evalua si el nivel está en Edit mode

        yield return null;
    }

    [TearDown]
    public void TearDown()
    {

    }


}
