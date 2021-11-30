using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LugarGlobal : MonoBehaviour
{
    int lugarEscenario;
    int numLugar;
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

    bool lugar1 = false;
    bool lugar2 = false;
    bool lugar3 = false;
    bool lugar4 = false;
    List<int> lugaresConfigurados = new List<int>();

    public GameObject buttonLugar1;
    public GameObject buttonLugar2;
    public GameObject buttonLugar3;
    public GameObject buttonLugar4;

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
        if (!LevelSelect.lvlTutorialCirculatorio && !LevelSelect.lvlTutorialNervioso && !LevelSelect.lvlTutorialRespiratorio) {
            if (SistemaSelect.SistemaRespiratorioEntrar){

                if (PlayerPrefs.GetInt("isPulmonIzq") == 1)
                {
                    lugar1 = true;
                }
                else
                {
                    lugar1 = false;
                }

                if (PlayerPrefs.GetInt("isPulmonDer") == 1)
                {
                    lugar2 = true;
                }
                else
                {
                    lugar2 = false;
                }
                if (PlayerPrefs.GetInt("isTraquea") == 1)
                {
                    lugar3 = true;
                }
                else
                {
                    lugar3 = false;
                }
                if (PlayerPrefs.GetInt("isFosas") == 1)
                {
                    lugar4 = true;
                }
                else
                {
                    lugar4 = false;
                }

                if (lugar1)
                {
                    lugaresConfigurados.Add(1);
                    buttonLugar1.GetComponent<Button>().interactable = true;
                }
                if (lugar2)
                {
                    lugaresConfigurados.Add(2);
                    buttonLugar2.GetComponent<Button>().interactable = true;
                }
                if (lugar3)
                {
                    lugaresConfigurados.Add(3);
                    buttonLugar3.GetComponent<Button>().interactable = true;
                }
                if (lugar4)
                {
                    lugaresConfigurados.Add(4);
                    buttonLugar4.GetComponent<Button>().interactable = true;
                }
                if (!lugar1 && !lugar2 && !lugar3 && !lugar4)
                {
                    lugaresConfigurados.Add(1);
                    lugaresConfigurados.Add(2);
                    lugaresConfigurados.Add(3);
                    lugaresConfigurados.Add(4);
                    buttonLugar1.GetComponent<Button>().interactable = true;
                    buttonLugar2.GetComponent<Button>().interactable = true;
                    buttonLugar3.GetComponent<Button>().interactable = true;
                    buttonLugar4.GetComponent<Button>().interactable = true;
                }
            }
            else if (SistemaSelect.SistemaCirculatorioEntrar)
            {
                if (PlayerPrefs.GetInt("isArterias") == 1)
                {
                    lugar1 = true;
                }
                else
                {
                    lugar1 = false;
                }

                if (PlayerPrefs.GetInt("isVenas") == 1)
                {
                    lugar2 = true;
                }
                else
                {
                    lugar2 = false;
                }
                if (PlayerPrefs.GetInt("isCorazon") == 1)
                {
                    lugar3 = true;
                }
                else
                {
                    lugar3 = false;
                }
                if (PlayerPrefs.GetInt("isCapilares") == 1)
                {
                    lugar4 = true;
                }
                else
                {
                    lugar4 = false;
                }

                if (lugar1)
                {
                    lugaresConfigurados.Add(1);
                    buttonLugar1.GetComponent<Button>().interactable = true;
                }
                if (lugar2)
                {
                    lugaresConfigurados.Add(2);
                    buttonLugar2.GetComponent<Button>().interactable = true;
                }
                if (lugar3)
                {
                    lugaresConfigurados.Add(3);
                    buttonLugar3.GetComponent<Button>().interactable = true;
                }
                if (lugar4)
                {
                    lugaresConfigurados.Add(4);
                    buttonLugar4.GetComponent<Button>().interactable = true;
                }
                if (!lugar1 && !lugar2 && !lugar3 && !lugar4)
                {
                    lugaresConfigurados.Add(1);
                    lugaresConfigurados.Add(2);
                    lugaresConfigurados.Add(3);
                    lugaresConfigurados.Add(4);
                    buttonLugar1.GetComponent<Button>().interactable = true;
                    buttonLugar2.GetComponent<Button>().interactable = true;
                    buttonLugar3.GetComponent<Button>().interactable = true;
                    buttonLugar4.GetComponent<Button>().interactable = true;
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("isEncefalo") == 1)
                {
                    lugar1 = true;
                }
                else
                {
                    lugar1 = false;
                }

                if (PlayerPrefs.GetInt("isNervios") == 1)
                {
                    lugar2 = true;
                }
                else
                {
                    lugar2 = false;
                }
                if (PlayerPrefs.GetInt("isMedula") == 1)
                {
                    lugar3 = true;
                }
                else
                {
                    lugar3 = false;
                }
                if (PlayerPrefs.GetInt("isGanglios") == 1)
                {
                    lugar4 = true;
                }
                else
                {
                    lugar4 = false;
                }

                if (lugar1)
                {
                    lugaresConfigurados.Add(1);
                    buttonLugar1.GetComponent<Button>().interactable = true;
                }
                if (lugar2)
                {
                    lugaresConfigurados.Add(2);
                    buttonLugar2.GetComponent<Button>().interactable = true;
                }
                if (lugar3)
                {
                    lugaresConfigurados.Add(3);
                    buttonLugar3.GetComponent<Button>().interactable = true;
                }
                if (lugar4)
                {
                    lugaresConfigurados.Add(4);
                    buttonLugar4.GetComponent<Button>().interactable = true;
                }
                if (!lugar1 && !lugar2 && !lugar3 && !lugar4)
                {
                    lugaresConfigurados.Add(1);
                    lugaresConfigurados.Add(2);
                    lugaresConfigurados.Add(3);
                    lugaresConfigurados.Add(4);
                    buttonLugar1.GetComponent<Button>().interactable = true;
                    buttonLugar2.GetComponent<Button>().interactable = true;
                    buttonLugar3.GetComponent<Button>().interactable = true;
                    buttonLugar4.GetComponent<Button>().interactable = true;
                }
            }
        }
        var rand = new System.Random();
        int index = rand.Next(0, lugaresConfigurados.ToArray().Length);
        numLugar = lugaresConfigurados[index];
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

            if (lugaresConfigurados.Count <= 1)
            {
                var range = lugaresConfigurados.ToArray();

                var rand = new System.Random();
                int index = rand.Next(0, lugaresConfigurados.ToArray().Length);
                numLugar = range.ElementAt(index);
            }
            else
            {
                var exclude = new HashSet<int>() { numLugar };
                //var range = Enumerable.Range(1, 5).Where(i => !exclude.Contains(i));
                var range = lugaresConfigurados.ToArray().Where(i => !exclude.Contains(i));

                var rand = new System.Random();
                int index = rand.Next(0, lugaresConfigurados.ToArray().Length - exclude.Count);
                numLugar = range.ElementAt(index);
            }

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
