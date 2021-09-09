using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectEcosistema : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;

    public static bool lvl1ForestEntrar = false;
    public static bool lvl2ForestEntrar = false;
    public static bool lvl3ForestEntrar = false;
    public static bool lvl4ForestEntrar = false;
    public static bool lvl5ForestEntrar = false;
    public static bool lvl6ForestEntrar = false;

    public static bool lvlTutorialForest = false;

    public int lvl1Forest = 401;
    public int lvl2Forest = 402;
    public int lvl3Forest = 403;
    public int lvl4Forest = 404;
    public int lvl5Forest = 405;
    public int lvl6Forest = 406;

    // Start is called before the first frame update
    void Start()
    {
        lvl1ForestEntrar = false;
        lvl2ForestEntrar = false;
        lvl3ForestEntrar = false;
        lvl4ForestEntrar = false;
        lvl5ForestEntrar = false;
        lvl6ForestEntrar = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Level1() {
        lvl1ForestEntrar = true;
        Manager.LvlIngresado = lvl1Forest;
        SceneManager.LoadScene(42);
    }

    public void Level2()
    {
        lvl2ForestEntrar = true;
        Manager.LvlIngresado = lvl2Forest;
        SceneManager.LoadScene(43);
    }

    public void Level3()
    {
        lvl3ForestEntrar = true;
        Manager.LvlIngresado = lvl3Forest;
        SceneManager.LoadScene(44);
    }

    public void Level4()
    {
        lvl4ForestEntrar = true;
        Manager.LvlIngresado = lvl4Forest;
        SceneManager.LoadScene(45);
    }

    public void Level5()
    {
        lvl5ForestEntrar = true;
        Manager.LvlIngresado = lvl5Forest;
        SceneManager.LoadScene(46);
    }

    public void Level6()
    {
        lvl6ForestEntrar = true;
        Manager.LvlIngresado = lvl6Forest;
        SceneManager.LoadScene(47);
    }

    public void Regresar()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        lvlTutorialForest = true;
        Manager.LvlIngresado = 400;
        SceneManager.LoadScene(48);
    }
}
