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
    public GameObject NVirusEliminados1;
    public GameObject PuntajeReal2;
    public GameObject NVirusEliminados2;
    public GameObject PuntajeReal3;
    public GameObject NVirusEliminados3;
    public GameObject PuntajeReal4;
    public GameObject NVirusEliminados4;
    public GameObject PuntajeReal5;
    public GameObject NVirusEliminados5;
    public GameObject PuntajeReal6;
    public GameObject NVirusEliminados6;

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
            PlayerPrefs.SetInt("Puntaje1", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt("NVirus1", SScoreGlobal.EliminadosCount);
            PuntajeReal1.GetComponent<Text>().text = SScoreGlobal.ScoreCount.ToString();
            NVirusEliminados1.GetComponent<Text>().text = SScoreGlobal.EliminadosCount.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;
            lvl1Superado = false;
        }
        if (lvl2Superado == true)
        {
            int puntaje1 = PlayerPrefs.GetInt("Puntaje1");
            int NVirus1 = PlayerPrefs.GetInt("NVirus1");
            PuntajeReal1.GetComponent<Text>().text = puntaje1.ToString();
            NVirusEliminados1.GetComponent<Text>().text = NVirus1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("Puntaje2", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt("NVirus2", SScoreGlobal.EliminadosCount);
            PuntajeReal2.GetComponent<Text>().text = SScoreGlobal.ScoreCount.ToString();
            NVirusEliminados2.GetComponent<Text>().text = SScoreGlobal.EliminadosCount.ToString();
            Lock3.SetActive(false);
            Button3.GetComponent<Button>().interactable = true;
            lvl2Superado = false;
        }
        if (lvl3Superado == true)
        {
            int puntaje1 = PlayerPrefs.GetInt("Puntaje1");
            int NVirus1 = PlayerPrefs.GetInt("NVirus1");
            PuntajeReal1.GetComponent<Text>().text = puntaje1.ToString();
            NVirusEliminados1.GetComponent<Text>().text = NVirus1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;

            int puntaje2 = PlayerPrefs.GetInt("Puntaje2");
            int NVirus2 = PlayerPrefs.GetInt("NVirus2");
            PuntajeReal2.GetComponent<Text>().text = puntaje2.ToString();
            NVirusEliminados2.GetComponent<Text>().text = NVirus2.ToString();
            Lock3.SetActive(false);
            Button3.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("Puntaje3", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt("NVirus3", SScoreGlobal.EliminadosCount);
            PuntajeReal3.GetComponent<Text>().text = SScoreGlobal.ScoreCount.ToString();
            NVirusEliminados3.GetComponent<Text>().text = SScoreGlobal.EliminadosCount.ToString();
            Lock4.SetActive(false);
            Button4.GetComponent<Button>().interactable = true;
            lvl3Superado = false;
        }
        if (lvl4Superado == true)
        {
            int puntaje1 = PlayerPrefs.GetInt("Puntaje1");
            int NVirus1 = PlayerPrefs.GetInt("NVirus1");
            PuntajeReal1.GetComponent<Text>().text = puntaje1.ToString();
            NVirusEliminados1.GetComponent<Text>().text = NVirus1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;

            int puntaje2 = PlayerPrefs.GetInt("Puntaje2");
            int NVirus2 = PlayerPrefs.GetInt("NVirus2");
            PuntajeReal2.GetComponent<Text>().text = puntaje2.ToString();
            NVirusEliminados2.GetComponent<Text>().text = NVirus2.ToString();
            Lock3.SetActive(false);
            Button3.GetComponent<Button>().interactable = true;

            int puntaje3 = PlayerPrefs.GetInt("Puntaje3");
            int NVirus3 = PlayerPrefs.GetInt("NVirus3");
            PuntajeReal3.GetComponent<Text>().text = puntaje3.ToString();
            NVirusEliminados3.GetComponent<Text>().text = NVirus3.ToString();
            Lock4.SetActive(false);
            Button4.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("Puntaje4", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt("NVirus4", SScoreGlobal.EliminadosCount);
            PuntajeReal4.GetComponent<Text>().text = SScoreGlobal.ScoreCount.ToString();
            NVirusEliminados4.GetComponent<Text>().text = SScoreGlobal.EliminadosCount.ToString();
            Lock5.SetActive(false);
            Button5.GetComponent<Button>().interactable = true;
            lvl4Superado = false;
        }
        if (lvl5Superado == true)
        {
            int puntaje1 = PlayerPrefs.GetInt("Puntaje1");
            int NVirus1 = PlayerPrefs.GetInt("NVirus1");
            PuntajeReal1.GetComponent<Text>().text = puntaje1.ToString();
            NVirusEliminados1.GetComponent<Text>().text = NVirus1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;

            int puntaje2 = PlayerPrefs.GetInt("Puntaje2");
            int NVirus2 = PlayerPrefs.GetInt("NVirus2");
            PuntajeReal2.GetComponent<Text>().text = puntaje2.ToString();
            NVirusEliminados2.GetComponent<Text>().text = NVirus2.ToString();
            Lock3.SetActive(false);
            Button3.GetComponent<Button>().interactable = true;

            int puntaje3 = PlayerPrefs.GetInt("Puntaje3");
            int NVirus3 = PlayerPrefs.GetInt("NVirus3");
            PuntajeReal3.GetComponent<Text>().text = puntaje3.ToString();
            NVirusEliminados3.GetComponent<Text>().text = NVirus3.ToString();
            Lock4.SetActive(false);
            Button4.GetComponent<Button>().interactable = true;

            int puntaje4 = PlayerPrefs.GetInt("Puntaje4");
            int NVirus4 = PlayerPrefs.GetInt("NVirus4");
            PuntajeReal4.GetComponent<Text>().text = puntaje4.ToString();
            NVirusEliminados4.GetComponent<Text>().text = NVirus4.ToString();
            Lock5.SetActive(false);
            Button5.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("Puntaje5", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt("NVirus5", SScoreGlobal.EliminadosCount);
            PuntajeReal5.GetComponent<Text>().text = SScoreGlobal.ScoreCount.ToString();
            NVirusEliminados5.GetComponent<Text>().text = SScoreGlobal.EliminadosCount.ToString();
            Lock6.SetActive(false);
            Button6.GetComponent<Button>().interactable = true;
            lvl5Superado = false;
        }
        if (lvl6Superado == true)
        {
            int puntaje1 = PlayerPrefs.GetInt("Puntaje1");
            int NVirus1 = PlayerPrefs.GetInt("NVirus1");
            PuntajeReal1.GetComponent<Text>().text = puntaje1.ToString();
            NVirusEliminados1.GetComponent<Text>().text = NVirus1.ToString();
            Lock2.SetActive(false);
            Button2.GetComponent<Button>().interactable = true;

            int puntaje2 = PlayerPrefs.GetInt("Puntaje2");
            int NVirus2 = PlayerPrefs.GetInt("NVirus2");
            PuntajeReal2.GetComponent<Text>().text = puntaje2.ToString();
            NVirusEliminados2.GetComponent<Text>().text = NVirus2.ToString();
            Lock3.SetActive(false);
            Button3.GetComponent<Button>().interactable = true;

            int puntaje3 = PlayerPrefs.GetInt("Puntaje3");
            int NVirus3 = PlayerPrefs.GetInt("NVirus3");
            PuntajeReal3.GetComponent<Text>().text = puntaje3.ToString();
            NVirusEliminados3.GetComponent<Text>().text = NVirus3.ToString();
            Lock4.SetActive(false);
            Button4.GetComponent<Button>().interactable = true;

            int puntaje4 = PlayerPrefs.GetInt("Puntaje4");
            int NVirus4 = PlayerPrefs.GetInt("NVirus4");
            PuntajeReal4.GetComponent<Text>().text = puntaje4.ToString();
            NVirusEliminados4.GetComponent<Text>().text = NVirus4.ToString();
            Lock5.SetActive(false);
            Button5.GetComponent<Button>().interactable = true;

            int puntaje5 = PlayerPrefs.GetInt("Puntaje5");
            int NVirus5 = PlayerPrefs.GetInt("NVirus5");
            PuntajeReal5.GetComponent<Text>().text = puntaje5.ToString();
            NVirusEliminados5.GetComponent<Text>().text = NVirus5.ToString();
            Lock6.SetActive(false);
            Button6.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetInt("Puntaje6", SScoreGlobal.ScoreCount);
            PlayerPrefs.SetInt("NVirus6", SScoreGlobal.EliminadosCount);
            PuntajeReal6.GetComponent<Text>().text = SScoreGlobal.ScoreCount.ToString();
            NVirusEliminados6.GetComponent<Text>().text = SScoreGlobal.EliminadosCount.ToString();
            lvl6Superado = false;
        }
    }

    public void Level1() {
        lvl1Entrar = true;
        SceneManager.LoadScene(5);
    }

    public void Level2()
    {
        lvl2Entrar = true;
        SceneManager.LoadScene(9);
    }

    public void Level3()
    {
        lvl3Entrar = true;
        SceneManager.LoadScene(10);
    }

    public void Level4()
    {
        lvl4Entrar = true;
        SceneManager.LoadScene(16);
    }

    public void Level5()
    {
        lvl5Entrar = true;
        SceneManager.LoadScene(17);
    }

    public void Level6()
    {
        lvl6Entrar = true;
        SceneManager.LoadScene(18);
    }


    public void Regresar()
    {
        SceneManager.LoadScene(11);
    }
}
