using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LugarGlobal : MonoBehaviour
{
    public int lugarVirus;
    public int numLugar = 3;
    public bool entroNivel = false;
    public GameObject enemigosUI;
    public GameObject sistemaRespiratorioUI;
    public GameObject advertenciaUI;
    public GameObject regresarButton;
    public static int numVirusNecesarios;
    public int numVirusRequeridos;

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
            var range = Enumerable.Range(1, 4).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 3 - exclude.Count);
            numLugar = range.ElementAt(index);
            Debug.Log("NumLugar: " + numLugar);
            numVirusRequeridos = numVirusRequeridos * 2;
        }
    }
    public void PulmonDer()
    {
        regresarButton.SetActive(true);
        lugarVirus = 3;
        entroNivel = true;
        lugarCorrecto();
    }
    public void PulmonIzq()
    {
        regresarButton.SetActive(true);
        entroNivel = true;
        lugarVirus = 2;
        lugarCorrecto();
    }
    public void Tronco()
    {
        regresarButton.SetActive(true);
        entroNivel = true;
        lugarVirus = 1;
        lugarCorrecto();
    }

    public void lugarCorrecto()
    {
        sistemaRespiratorioUI.SetActive(false);
        if (lugarVirus == numLugar)
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
