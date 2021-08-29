using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform objectToMove;
    public float speed1;
    public float speed2;
    public GameObject cuadroText;
    public GameObject cuadro;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;
    public GameObject button11;
    public GameObject button12;
    public GameObject button13;
    public GameObject button14;
    public GameObject button15;
    public GameObject button16;
    public GameObject button17;
    public GameObject button18;
    public GameObject button19;
    public GameObject button20;
    public GameObject button21;
    public GameObject button22;
    public GameObject button23;

    public GameObject tutorialText;
    public GameObject pizarra;
    public GameObject virus;
    public GameObject virus2;
    public GameObject virus3;
    public GameObject virus4;
    public GameObject corazon;
    public GameObject celula;
    public GameObject informaci�nText;
    public GameObject informaci�nText2;
    public GameObject informaci�nText3;
    public GameObject informaci�nText4;
    public GameObject informaci�nText5;
    public GameObject informaci�nText6;

    public GameObject virusEjemplo;
    public GameObject virusEjemplo2;
    public GameObject virusEjemplo3;
    public GameObject virusEjemplo4;

    bool virus1eliminado = false;
    bool virus2eliminado = false;
    bool virus3eliminado = false;
    bool virus4eliminado = false;
    bool bandera = true;

    public AudioSource audioClick;

    public Sprite[] sprites;

    bool point1;
    bool point2;
    bool point3;
    bool point4;

    // Start is called before the first frame update
    void Start()
    {
        point1 = true;
        point2 = false;
        point3 = false;
        point4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (point1 == true)
        {
            float step = speed1 * Time.deltaTime;
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, target1.position, step);
        }
        else if (point2 == true)
        {
            float step = speed2 * Time.deltaTime;
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, step);
        }
        if (virusEjemplo == null)
        {
            virus1eliminado = true;
        }
        if (virusEjemplo2 == null)
        {
            virus2eliminado = true;
        }
        if (virusEjemplo3 == null)
        {
            virus3eliminado = true;
        }
        if (virusEjemplo4 == null)
        {
            virus4eliminado = true;
        }
        if (virus1eliminado && virus2eliminado && virus3eliminado && virus4eliminado && bandera)
        {
            PassPoint22();
        }
    }

    public void PassPoint2()
    {
        audioClick.Play();
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target1.position, 50);
        tutorialText.SetActive(false);
        cuadro.SetActive(true);
        point1 = false;
        button1.SetActive(false);
        button2.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Hola! Soy la sustancia que entr� por la vacuna.\nPuedes llamarme Sustin.";
    }
    public void PassPoint3()
    {
        audioClick.Play();
        button2.SetActive(false);
        button3.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Estoy aqu� porque tengo una misi�n.\n�Y ese es entrenarte para la batalla!";
    }
    public void PassPoint4()
    {
        audioClick.Play();
        button3.SetActive(false);
        button4.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Varias bacterias est�n a punto de entrar al organismo! Es tu misi�n eliminarlos y, para ello, te ense�ar� lo esencial.";
    }

    public void PassPoint5()
    {
        audioClick.Play();
        button4.SetActive(false);
        button5.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Cada enemigo tiene sus propias caracter�sticas y pueden aparecer en cualquier lado del organismo.";
    }

    public void PassPoint6()
    {
        audioClick.Play();
        point2 = true;
        button5.SetActive(false);
        button6.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Para entrenarte, me disfrazar� de cada enemigo y simular� sus caracter�sticas. Primero empecemos con el enemigo m�s com�n: La bacteria normal.";
    }
    public void PassPoint7()
    {
        audioClick.Play();
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, 50);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[1];
        point2 = false;
        pizarra.SetActive(true);
        virus.SetActive(true);
        informaci�nText.SetActive(true);
        button6.SetActive(false);
        button7.SetActive(true);
        cuadroText.GetComponent<Text>().text = "La bacteria normal tiene un ratio de aparici�n muy alto. Son las bacterias m�s debiles, pero pueden empezar a lastimarte si est�n mucho tiempo presentes en el escenario.";
    }
    public void PassPoint8()
    {
        audioClick.Play();
        button7.SetActive(false);
        button8.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Estas bacterias pueden causar efectos en el ser humano como tos y estornudos. Son la causante inicial de futuras enfermedades.";
    }

    public void PassPoint9()
    {
        audioClick.Play();
        button8.SetActive(false);
        button9.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[2];
        virus.SetActive(false);
        virus2.SetActive(true);
        informaci�nText.SetActive(false);
        informaci�nText2.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Por otro lado, la bacteria brillante tiene un ratio de aparici�n alto. Estas bacterias resisten un poco m�s que las bacterias normales pero su da�o es similar. ";
    }
    public void PassPoint10()
    {
        audioClick.Play();
        button9.SetActive(false);
        button10.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Estas bacterias pueden causar efectos en el ser humano como dolor de cabeza y problemas para respirar. �Hay que tener cuidado!";
    }
    public void PassPoint11()
    {
        audioClick.Play();
        button10.SetActive(false);
        button11.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[3];
        virus2.SetActive(false);
        virus3.SetActive(true);
        informaci�nText2.SetActive(false);
        informaci�nText3.SetActive(true);
        cuadroText.GetComponent<Text>().text = "La bacteria resistente tiene un ratio de aparici�n menor que las 2 bacterias anteriores pero son resistentes y su da�o de ataque es mayor.";
    }
    public void PassPoint12()
    {
        audioClick.Play();
        button11.SetActive(false);
        button12.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Estas bacterias pueden causar efectos en el ser humano como fiebre y estornudos fuertes. �Son muy peligrosas!";
    }
    public void PassPoint13()
    {
        audioClick.Play();
        button12.SetActive(false);
        button13.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[3];
        virus3.SetActive(false);
        virus4.SetActive(true);
        informaci�nText3.SetActive(false);
        informaci�nText4.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Finalmente la �ltima bacteria: La bacteria jefe. Esta bacteria es el m�s resistente de las 4 anteriores, pero aparecen muy poco.";
    }
    public void PassPoint14()
    {
        audioClick.Play();
        button13.SetActive(false);
        button14.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Sin embargo, estas bacterias son muy peligrosas para el organismo. Pueden causar fiebre alta y tos intensa. �Hay que eliminarlas cuanto antes!";
    }
    public void PassPoint15()
    {
        audioClick.Play();
        button14.SetActive(false);
        button15.SetActive(true);
        objectToMove.GetComponent<SpriteRenderer>().sprite = sprites[0];
        virus4.SetActive(false);
        corazon.SetActive(true);
        informaci�nText4.SetActive(false);
        informaci�nText5.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Tambi�n podr�s encontrar el objecto Coraz�n durante la batalla!";
    }
    public void PassPoint16()
    {
        audioClick.Play();
        button15.SetActive(false);
        button16.SetActive(true);
        cuadroText.GetComponent<Text>().text = "El objeto Coraz�n es muy �til para recuperar vida. Cuando menos te lo esperes, este objeto puede salvarte.";
    }
    public void PassPoint17()
    {
        audioClick.Play();
        button16.SetActive(false);
        button17.SetActive(true);
        corazon.SetActive(false);
        celula.SetActive(true);
        informaci�nText5.SetActive(false);
        informaci�nText6.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Tambi�n puedes encontrarte con individuos indefensos como las c�lulas. Eso s�, recuerda evitar atacarlos porque est�n en el mismo bando.";
    }
    public void PassPoint18()
    {
        audioClick.Play();
        button17.SetActive(false);
        button18.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Despues de un tiempo desaparecen del escenario. Mientras tanto, tu atenci�n debe estar con las bacterias. �No lo olvides!";
    }
    public void PassPoint19()
    {
        audioClick.Play();
        point1 = true;
        pizarra.SetActive(false);
        informaci�nText6.SetActive(false);
        celula.SetActive(false);
        button18.SetActive(false);
        button19.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Ups, se me olvidaba!. Para eliminar a las bacterias, debes tocarlos con la pantalla t�ctil.";
    }
    public void PassPoint20()
    {
        audioClick.Play();
        point1 = false;
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target1.position, 50);
        button19.SetActive(false);
        button20.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Un toque equivale a 1 de da�o. �Tienes que eliminarlos antes que ellos te hagan da�o!. Si est�n mucho tiempo en el escenario, empezar�n a atacarte.";
    }
    public void PassPoint21()
    {
        audioClick.Play();
        point2 = true;
        button20.SetActive(false);
        virusEjemplo.SetActive(true);
        virusEjemplo2.SetActive(true);
        virusEjemplo3.SetActive(true);
        virusEjemplo4.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Mira, aparecieron enemigos! Justo a tiempo. Intenta eliminarlos haciendo toques con la pantalla t�ctil.";
    }
    public void PassPoint22()
    {
        bandera = false;
        audioClick.Play();
        point2 = false;
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, 50);
        button21.SetActive(false);
        button22.SetActive(true);
        cuadroText.GetComponent<Text>().text = "�Bien hecho! Con este tutorial ya est�s listo para la batalla.";
    }
    public void PassPoint23()
    {
        audioClick.Play();
        point1 = true;
        button22.SetActive(false);
        button23.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Si te olvidas de algo siempre puedes consultar este tutorial.\n Ahora si, �nos vemos!";
    }
    public void PassPoint24()
    {
        audioClick.Play();
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target1.position, 50);
        point1 = false;
        button23.SetActive(false);
        SceneManager.LoadScene(8);
    }
}
