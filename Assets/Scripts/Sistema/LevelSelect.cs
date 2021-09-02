using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;

    public static bool lvl1Entrar = false;
    public static bool lvl2Entrar = false;
    public static bool lvl3Entrar = false;
    public static bool lvl4Entrar = false;
    public static bool lvl5Entrar = false;
    public static bool lvl6Entrar = false;

    public static bool lvl1EntrarCirculatorio = false;
    public static bool lvl2EntrarCirculatorio = false;
    public static bool lvl3EntrarCirculatorio = false;
    public static bool lvl4EntrarCirculatorio = false;
    public static bool lvl5EntrarCirculatorio = false;
    public static bool lvl6EntrarCirculatorio = false;

    public static bool lvl1EntrarNervioso = false;
    public static bool lvl2EntrarNervioso = false;
    public static bool lvl3EntrarNervioso = false;
    public static bool lvl4EntrarNervioso = false;
    public static bool lvl5EntrarNervioso = false;
    public static bool lvl6EntrarNervioso = false;

    public static bool lvlTutorialRespiratorio = false;
    public static bool lvlTutorialCirculatorio = false;
    public static bool lvlTutorialNervioso = false;

    public int lvl1Resp = 101;
    public int lvl2Resp = 102;
    public int lvl3Resp = 103;
    public int lvl4Resp = 104;
    public int lvl5Resp = 105;
    public int lvl6Resp = 106;

    public int lvl1Circ = 201;
    public int lvl2Circ = 202;
    public int lvl3Circ = 203;
    public int lvl4Circ = 204;
    public int lvl5Circ = 205;
    public int lvl6Circ = 206;

    public int lvl1Ner = 301;
    public int lvl2Ner = 302;
    public int lvl3Ner = 303;
    public int lvl4Ner = 304;
    public int lvl5Ner = 305;
    public int lvl6Ner = 306;

    public GameObject Lock2;
    public GameObject Lock3;
    public GameObject Lock4;
    public GameObject Lock5;
    public GameObject Lock6;


    // Start is called before the first frame update
    void Start()
    {
        lvl1Entrar = false;
        lvl2Entrar = false;
        lvl3Entrar = false;
        lvl4Entrar = false;
        lvl5Entrar = false;
        lvl6Entrar = false;

        lvl1EntrarCirculatorio = false;
        lvl2EntrarCirculatorio = false;
        lvl3EntrarCirculatorio = false;
        lvl4EntrarCirculatorio = false;
        lvl5EntrarCirculatorio = false;
        lvl6EntrarCirculatorio = false;

        lvl1EntrarNervioso = false;
        lvl2EntrarNervioso = false;
        lvl3EntrarNervioso = false;
        lvl4EntrarNervioso = false;
        lvl5EntrarNervioso = false;
        lvl6EntrarNervioso = false;
}

    // Update is called once per frame
    void Update()
    {

    }

    public void Level1() {
        lvl1Entrar = true;
        STimeGlobal.LvlIngresado = lvl1Resp;
        SceneManager.LoadScene(5);
    }

    public void Level2()
    {
        lvl2Entrar = true;
        STimeGlobal.LvlIngresado = lvl2Resp;
        SceneManager.LoadScene(9);
    }

    public void Level3()
    {
        lvl3Entrar = true;
        STimeGlobal.LvlIngresado = lvl3Resp;
        SceneManager.LoadScene(10);
    }

    public void Level4()
    {
        lvl4Entrar = true;
        STimeGlobal.LvlIngresado = lvl4Resp;
        SceneManager.LoadScene(16);
    }

    public void Level5()
    {
        lvl5Entrar = true;
        STimeGlobal.LvlIngresado = lvl5Resp;
        SceneManager.LoadScene(17);
    }

    public void Level6()
    {
        lvl6Entrar = true;
        STimeGlobal.LvlIngresado = lvl6Resp;
        SceneManager.LoadScene(18);
    }

    public void Level1Circulatorio()
    {
        lvl1EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl1Circ;
        SceneManager.LoadScene(25);
    }

    public void Level2Circulatorio()
    {
        lvl2EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl2Circ;
        SceneManager.LoadScene(27);
    }

    public void Level3Circulatorio()
    {
        lvl3EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl3Circ;
        SceneManager.LoadScene(28);
    }

    public void Level4Circulatorio()
    {
        lvl4EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl4Circ;
        SceneManager.LoadScene(29);
    }

    public void Level5Circulatorio()
    {
        lvl5EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl5Circ;
        SceneManager.LoadScene(30);
    }

    public void Level6Circulatorio()
    {
        lvl6EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl6Circ;
        SceneManager.LoadScene(31);
    }

    public void Level1Nervioso()
    {
        lvl1EntrarNervioso = true;
        STimeGlobal.LvlIngresado = lvl1Ner;
        SceneManager.LoadScene(34);
    }

    public void Level2Nervioso()
    {
        lvl2EntrarNervioso = true;
        STimeGlobal.LvlIngresado = lvl2Ner;
        SceneManager.LoadScene(35);
    }

    public void Level3Nervioso()
    {
        lvl3EntrarNervioso = true;
        STimeGlobal.LvlIngresado = lvl3Ner;
        SceneManager.LoadScene(36);
    }

    public void Level4Nervioso()
    {
        lvl4EntrarNervioso = true;
        STimeGlobal.LvlIngresado = lvl4Ner;
        SceneManager.LoadScene(37);
    }

    public void Level5Nervioso()
    {
        lvl5EntrarNervioso = true;
        STimeGlobal.LvlIngresado = lvl5Ner;
        SceneManager.LoadScene(38);
    }

    public void Level6Nervioso()
    {
        lvl6EntrarNervioso = true;
        STimeGlobal.LvlIngresado = lvl6Ner;
        SceneManager.LoadScene(39);
    }


    public void Regresar()
    {
        SceneManager.LoadScene(11);
    }

    public void Tutorial()
    {
        lvlTutorialRespiratorio = true;
        SceneManager.LoadScene(40);
    }
    public void TutorialCirculatorio()
    {
        lvlTutorialCirculatorio = true;
        SceneManager.LoadScene(32);
    }

    public void TutorialNervioso()
    {
        lvlTutorialNervioso = true;
        SceneManager.LoadScene(41);
    }
}
