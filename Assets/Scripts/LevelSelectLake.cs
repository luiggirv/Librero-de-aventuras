using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectLake : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;

    public static bool lvl1Superado = false;
    public static bool lvl2Superado = false;
    public static bool lvl3Superado = false;
    public static bool lvl4Superado = false;
    public static bool lvl5Superado = false;
    public static bool lvl6Superado = false;

    public static bool lvl1Entrar = false;
    public static bool lvl2Entrar = false;
    public static bool lvl3Entrar = false;
    public static bool lvl4Entrar = false;
    public static bool lvl5Entrar = false;
    public static bool lvl6Entrar = false;

    public GameObject PuntajeReal1;
    public GameObject PuntajeReal2;
    public GameObject PuntajeReal3;

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
        if (lvl1Superado == true)
        {
            PlayerPrefs.SetInt("PuntajeLake1", GameplayManager.PuntajeLvl1);
            PuntajeReal1.GetComponent<Text>().text = GameplayManager.PuntajeLvl1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;
            lvl1Superado = false;
        }
        if (lvl2Superado == true)
        {
            int puntaje1 = PlayerPrefs.GetInt("PuntajeLake1");
            PuntajeReal1.GetComponent<Text>().text = puntaje1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("PuntajeLake2", GameplayManager.PuntajeLvl2);
            PuntajeReal2.GetComponent<Text>().text = GameplayManager.PuntajeLvl2.ToString();
            Lock3.SetActive(false);
            Button3.GetComponent<Button>().interactable = true;
            lvl2Superado = false;
        }
        if (lvl3Superado == true)
        {
            int puntaje1 = PlayerPrefs.GetInt("PuntajeLake1");
            PuntajeReal1.GetComponent<Text>().text = puntaje1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;

            int puntaje2 = PlayerPrefs.GetInt("PuntajeLake2");
            PuntajeReal2.GetComponent<Text>().text = puntaje2.ToString();
            Lock3.SetActive(false);
            Button3.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("PuntajeLake3", GameplayManager.PuntajeLvl3);
            PuntajeReal3.GetComponent<Text>().text = GameplayManager.PuntajeLvl3.ToString();
            Lock4.SetActive(false);
            Button4.GetComponent<Button>().interactable = true;
            lvl3Superado = false;
        }
    }

    public void Level1() {
        lvl1Entrar = true;
        SceneManager.LoadScene(7);
    }

    public void Level2()
    {
        lvl2Entrar = true;
        //SceneManager.LoadScene(9);
    }

    public void Level3()
    {
        lvl3Entrar = true;
        //SceneManager.LoadScene(10);
    }


    public void Regresar()
    {
        SceneManager.LoadScene(12);
    }
}
