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
        SceneManager.LoadScene(9);
    }

    public void Level3Circulatorio()
    {
        lvl3EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl3Circ;
        SceneManager.LoadScene(10);
    }

    public void Level4Circulatorio()
    {
        lvl4EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl4Circ;
        SceneManager.LoadScene(16);
    }

    public void Level5Circulatorio()
    {
        lvl5EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl5Circ;
        SceneManager.LoadScene(17);
    }

    public void Level6Circulatorio()
    {
        lvl6EntrarCirculatorio = true;
        STimeGlobal.LvlIngresado = lvl6Circ;
        SceneManager.LoadScene(18);
    }


    public void Regresar()
    {
        SceneManager.LoadScene(11);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(24);
    }
}
