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

    public static bool lvl1MountainEntrar = false;
    public static bool lvl2MountainEntrar = false;
    public static bool lvl3MountainEntrar = false;
    public static bool lvl4MountainEntrar = false;
    public static bool lvl5MountainEntrar = false;
    public static bool lvl6MountainEntrar = false;

    public static bool lvlTutorialMountain = false;

    public int lvl1Mountain = 601;
    public int lvl2Mountain = 602;
    public int lvl3Mountain = 603;
    public int lvl4Mountain = 604;
    public int lvl5Mountain = 605;
    public int lvl6Mountain = 606;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
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

        lvl1MountainEntrar = false;
        lvl2MountainEntrar = false;
        lvl3MountainEntrar = false;
        lvl4MountainEntrar = false;
        lvl5MountainEntrar = false;
        lvl6MountainEntrar = false;
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
        GameplayManager.LvlIngresado = lvl1Lake;
        SceneManager.LoadScene(7);
    }

    public void Level2Lake()
    {
        lvl2LakeEntrar = true;
        GameplayManager.LvlIngresado = lvl2Lake;
        SceneManager.LoadScene(49);
    }

    public void Level3Lake()
    {
        lvl3LakeEntrar = true;
        GameplayManager.LvlIngresado = lvl3Lake;
        SceneManager.LoadScene(50);
    }

    public void Level4Lake()
    {
        lvl4LakeEntrar = true;
        GameplayManager.LvlIngresado = lvl4Lake;
        SceneManager.LoadScene(51);
    }

    public void Level5Lake()
    {
        lvl5LakeEntrar = true;
        GameplayManager.LvlIngresado = lvl5Lake;
        SceneManager.LoadScene(52);
    }

    public void Level6Lake()
    {
        lvl6LakeEntrar = true;
        GameplayManager.LvlIngresado = lvl6Lake;
        SceneManager.LoadScene(53);
    }

    public void Level1Mountain()
    {
        lvl1MountainEntrar = true;
        GameController.LvlIngresado = lvl1Mountain;
        SceneManager.LoadScene(55);
    }

    public void Level2Mountain()
    {
        lvl2MountainEntrar = true;
        GameController.LvlIngresado = lvl2Mountain;
        SceneManager.LoadScene(56);
    }

    public void Level3Mountain()
    {
        lvl3MountainEntrar = true;
        GameController.LvlIngresado = lvl3Mountain;
        SceneManager.LoadScene(57);
    }

    public void Level4Mountain()
    {
        lvl4MountainEntrar = true;
        GameController.LvlIngresado = lvl4Mountain;
        SceneManager.LoadScene(58);
    }

    public void Level5Mountain()
    {
        lvl5MountainEntrar = true;
        GameController.LvlIngresado = lvl5Mountain;
        SceneManager.LoadScene(59);
    }

    public void Level6Mountain()
    {
        lvl6MountainEntrar = true;
        GameController.LvlIngresado = lvl6Mountain;
        SceneManager.LoadScene(60);
    }

    public void Regresar()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        lvlTutorialForest = true;
        GameplayManager.LvlIngresado = 400;
        SceneManager.LoadScene(48);
    }

    public void TutorialLake()
    {
        lvlTutorialLake = true;
        GameplayManager.LvlIngresado = 500;
        SceneManager.LoadScene(54);
    }

    public void TutorialMountain()
    {
        lvlTutorialMountain = true;
        GameController.LvlIngresado = 600;
        SceneManager.LoadScene(61);
    }

    public void LeaderBoardBosque()
    {
        SceneManager.LoadScene(84);
    }
    public void LeaderBoardLago()
    {
        SceneManager.LoadScene(85);
    }
    public void LeaderBoardMontaña()
    {
        SceneManager.LoadScene(86);
    }
}
