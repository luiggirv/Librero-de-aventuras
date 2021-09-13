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
    public GameObject menuButton;
    public static int numVirusNecesarios;
    public int numVirusRequeridos;
    public GameObject marcaAgua;
    public Sprite[] imagenesbackground;
    public GameObject preguntaText;
    public static bool lugarEquivocado = false;

    public AudioSource correctSound;
    public AudioSource incorrectSound;

    string[] preguntasRespiratorio =
    {
        "Es él más grande de los dos órganos en forma de cono que se encuentran dentro del pecho de una persona y proveen oxígeno al cuerpo.",
        "Es él más pequeño de los dos órganos en forma de cono que se encuentran dentro del pecho de una persona y proveen oxígeno al cuerpo.",
        "Vía respiratoria que va desde la laringe hacia los bronquios. Permite el intercambio de aire entre los pulmones y el exterior.",
        "Conducto que conecta la boca con el esófago y las fosas nasales con la laringe.",
        "Órgano tubular que se situa entre la faringe y la tráquea.",
        "Son dos cavidades que comunican el aparato respiratorio con el exterior por la nariz."
    };

    string[] preguntasCirculatorio =
    {
        "Es un vaso sanguíneo que se encarga de transportar la sangre oxigenada desde el corazón al resto del cuerpo y viceversa.",
        "Es un vaso sanguíneo cuya función es retornar la sangre poco oxigenada al corazón para que pueda ser oxigenada nuevamente en el pulmón.",
        "Órgano vital de todo ser humano cuya función consiste en bombear la sangre oxigenada hacia el resto del cuerpo y sangre desoxigenada hacia los pulmones.",
        "Son vasos sanguineos que unen las arterias y las venas para formar una red y permitir el intercambio de sustancias entre la sangre y los tejidos."

    };

    string[] preguntasNervioso =
    {
        "Órgano importante dentro de la cabeza que controla todas las funciones de un ser humano, como el pensamiento, las emociones, el movimiento, etc.",
        "Conjunto de fibras que conducen los impulsos que se reciben del sistema nervioso y se distribuyen por diferentes partes del cuerpo.",
        "Parte del sistema nervioso central que conecta el cerebro con los nervios para transportar los mensajes al resto del cuerpo.",
        "Órganos cuya funcion es filtrar sustancias que el líquido linfático transporta y contienen globulos blancos que ayudan a combatir infecciones y enfermedades."
    };
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
            advertenciaUI.GetComponent<Text>().text = "Has eliminado a todas las bacterias de este lugar.\n¡Revisa los otros escenarios!";
            advertenciaUI.SetActive(true);
            menuButton.SetActive(false);
            regresarButton.SetActive(true);

            var exclude = new HashSet<int>() { numLugar };
            var range = Enumerable.Range(1, 5).Where(i => !exclude.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, 4 - exclude.Count);
            numLugar = range.ElementAt(index);
            if (LevelSelect.lvl1Entrar || LevelSelect.lvl2Entrar || LevelSelect.lvl3Entrar || LevelSelect.lvl4Entrar || LevelSelect.lvl5Entrar || LevelSelect.lvl6Entrar)
            {
                if (numLugar == 4)
                {
                    var rand2 = new System.Random();
                    preguntaText.GetComponent<Text>().text = preguntasRespiratorio[rand2.Next(3, 6)];
                }
                else
                {
                    preguntaText.GetComponent<Text>().text = preguntasRespiratorio[numLugar - 1];
                }
                
            }
            else if (LevelSelect.lvl1EntrarCirculatorio || LevelSelect.lvl2EntrarCirculatorio || LevelSelect.lvl3EntrarCirculatorio || LevelSelect.lvl4EntrarCirculatorio || LevelSelect.lvl5EntrarCirculatorio || LevelSelect.lvl6EntrarCirculatorio)
            {
                preguntaText.GetComponent<Text>().text = preguntasCirculatorio[numLugar - 1];
            }
            else if (LevelSelect.lvl1EntrarNervioso || LevelSelect.lvl2EntrarNervioso || LevelSelect.lvl3EntrarNervioso || LevelSelect.lvl4EntrarNervioso || LevelSelect.lvl5EntrarNervioso || LevelSelect.lvl6EntrarNervioso)
            {
                preguntaText.GetComponent<Text>().text = preguntasNervioso[numLugar - 1];
            }
            
            Debug.Log("NumLugar: " + numLugar);
            numVirusRequeridos = numVirusRequeridos * 2;
        }
    }
    public void Escenario1()
    {
        menuButton.SetActive(false);
        regresarButton.SetActive(true);
        lugarEscenario = 1;
        entroNivel = true;
        marcaAgua.GetComponent<Image>().sprite = imagenesbackground[0];
        marcaAgua.SetActive(true);
        lugarCorrecto();
    }
    public void Escenario2()
    {
        menuButton.SetActive(false);
        regresarButton.SetActive(true);
        entroNivel = true;
        lugarEscenario = 2;
        marcaAgua.GetComponent<Image>().sprite = imagenesbackground[1];
        marcaAgua.SetActive(true);
        lugarCorrecto();
    }
    public void Escenario3()
    {
        menuButton.SetActive(false);
        regresarButton.SetActive(true);
        entroNivel = true;
        lugarEscenario = 3;
        marcaAgua.GetComponent<Image>().sprite = imagenesbackground[2];
        marcaAgua.SetActive(true);
        lugarCorrecto();
    }
    public void Escenario4()
    {
        menuButton.SetActive(false);
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
            correctSound.Play();
            menuButton.SetActive(true);
            lugarEquivocado = false;
            regresarButton.SetActive(false);
            enemigosUI.SetActive(true);
        }
        else
        {
            incorrectSound.Play();
            lugarEquivocado = true;
            advertenciaUI.GetComponent<Text>().text = "Las bacterias no se encuentran en este lugar.\n¡Revisa los otros escenarios antes que el tiempo se agote!";
            advertenciaUI.SetActive(true);
        }
    }
    public void Regresar()
    {
        if (entroNivel == true)
        {
            regresarButton.SetActive(false);
            menuButton.SetActive(true);
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
