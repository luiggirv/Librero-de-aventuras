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

    public static bool lvl1LakeEntrar = false;
    public static bool lvl2LakeEntrar = false;
    public static bool lvl3LakeEntrar = false;
    public static bool lvl4LakeEntrar = false;
    public static bool lvl5LakeEntrar = false;
    public static bool lvl6LakeEntrar = false;

    public static bool lvlTutorialLake = false;

    public int lvl1Lake = 501;
    public int lvl2Lake = 502;
    public int lvl3Lake = 503;
    public int lvl4Lake = 504;
    public int lvl5Lake = 505;
    public int lvl6Lake = 506;

    // Start is called before the first frame update
    void Start()
    {
        lvl1ForestEntrar = false;
        lvl2ForestEntrar = false;
        lvl3ForestEntrar = false;
        lvl4ForestEntrar = false;
        lvl5ForestEntrar = false;
        lvl6ForestEntrar = false;

        lvl1LakeEntrar = false;
        lvl2LakeEntrar = false;
        lvl3LakeEntrar = false;
        lvl4LakeEntrar = false;
        lvl5LakeEntrar = false;
        lvl6LakeEntrar = false;
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

    public void Level1Lake()
    {
        lvl1LakeEntrar = true;
        Manager.LvlIngresado = lvl1Lake;
        SceneManager.LoadScene(42);
    }

    public void Level2Lake()
    {
        lvl2LakeEntrar = true;
        Manager.LvlIngresado = lvl2Lake;
        SceneManager.LoadScene(43);
    }

    public void Level3Lake()
    {
        lvl3LakeEntrar = true;
        Manager.LvlIngresado = lvl3Lake;
        SceneManager.LoadScene(44);
    }

    public void Level4Lake()
    {
        lvl4LakeEntrar = true;
        Manager.LvlIngresado = lvl4Lake;
        SceneManager.LoadScene(45);
    }

    public void Level5Lake()
    {
        lvl5LakeEntrar = true;
        Manager.LvlIngresado = lvl5Lake;
        SceneManager.LoadScene(46);
    }

    public void Level6Lake()
    {
        lvl6LakeEntrar = true;
        Manager.LvlIngresado = lvl6Lake;
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
