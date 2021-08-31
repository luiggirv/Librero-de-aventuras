using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LugarGlobal : MonoBehaviour
{
    int lugarEscenario;
    public int numLugar;
    public bool entroNivel = false;
    public GameObject enemigosUI;
    public GameObject sistemaRespiratorioUI;
    public GameObject advertenciaUI;
    public GameObject regresarButton;
    public static int numVirusNecesarios;
    public int numVirusRequeridos;
    public GameObject marcaAgua;
    public Sprite[] imagenesbackground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numVirusNecesarios = numVirusRequeridos;
        if (SScoreGlobal.EliminadosCount == numVirusRequeridos)
        {
            enemigosUI.SetActive(false);
            var clones = GameObject.FindGameObjectsWithTag("Objeto");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            advertenciaUI.GetComponent<Text>().text = "Has eliminado a todos los virus de este lugar.\n¡Revisa los otros lugares!";
            advertenciaUI.SetActive(true);
            var exclude = new HashSet<int>() { numLugar };
            var range = Enumerable.Range(1, 5).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 4 - exclude.Count);
            numLugar = range.ElementAt(index);
            Debug.Log("NumLugar: " + numLugar);
            numVirusRequeridos = numVirusRequeridos * 2;
        }
    }
    public void Escenario1()
    {
        regresarButton.SetActive(true);
        lugarEscenario = 1;
        entroNivel = true;
        marcaAgua.GetComponent<Image>().sprite = imagenesbackground[0];
        marcaAgua.SetActive(true);
        lugarCorrecto();
    }
    public void Escenario2()
    {
        regresarButton.SetActive(true);
        entroNivel = true;
        lugarEscenario = 2;
        marcaAgua.GetComponent<Image>().sprite = imagenesbackground[1];
        marcaAgua.SetActive(true);
        lugarCorrecto();
    }
    public void Escenario3()
    {
        regresarButton.SetActive(true);
        entroNivel = true;
        lugarEscenario = 3;
        marcaAgua.GetComponent<Image>().sprite = imagenesbackground[2];
        marcaAgua.SetActive(true);
        lugarCorrecto();
    }
    public void Escenario4()
    {
        regresarButton.SetActive(true);
        entroNivel = true;
        lugarEscenario = 4;
        marcaAgua.GetComponent<Image>().sprite = imagenesbackground[3];
        marcaAgua.SetActive(true);
        lugarCorrecto();
    }

    public void lugarCorrecto()
    {
        sistemaRespiratorioUI.SetActive(false);
        if (lugarEscenario == numLugar)
        {
            enemigosUI.SetActive(true);
        }
        else
        {
            advertenciaUI.GetComponent<Text>().text = "Los virus no están en este lugar.\n¡Revisa otros lugares antes que el tiempo se agote!";
            advertenciaUI.SetActive(true);
        }
    }
    public void Regresar()
    {
        if (entroNivel == true)
        {
            regresarButton.SetActive(false);
            sistemaRespiratorioUI.SetActive(true);
            enemigosUI.SetActive(false);
            advertenciaUI.SetActive(false);
            entroNivel = false;
            marcaAgua.SetActive(false);
            var clonesVirus = GameObject.FindGameObjectsWithTag("Virus");
            foreach (var clone in clonesVirus)
            {
              Destroy(clone);
            }

            var clonesObjetos = GameObject.FindGameObjectsWithTag("Objeto");
            foreach (var clone in clonesObjetos)
            {
                Destroy(clone);
            }
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }
}
