using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform objectToMove;
    public float speed1;
    public float speed2;
    public GameObject cuadroText;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;

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
    }

    public void PassPoint2()
    {
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target1.position, 50);

        point1 = false;
        button1.SetActive(false);
        button2.SetActive(true);
        cuadroText.GetComponent<Text>().text = "¡Hola! Soy la sustancia que entró por la vacuna.\nPuedes llamarme Sustin.";
    }
    public void PassPoint3()
    {
        button2.SetActive(false);
        button3.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Estoy aquí porque tengo una misión.\n¡Y ese es entrenarte para la batalla!";
    }
    public void PassPoint4()
    {
        button3.SetActive(false);
        button4.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Varios virus y bacterias están a punto de entrar al organismo y es tu misión eliminarlos.\nPara ello te enseñaré la apariencia de cada enemigo.";
    }

    public void PassPoint5()
    {
        button4.SetActive(false);
        button5.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Cada enemigo tiene sus características y pueden aparecer en cualquier lado. Para ello, te enseñaré lo esencial.";
    }

    public void PassPoint6()
    {
        point2 = true;
        button5.SetActive(false);
        button6.SetActive(true);
        cuadroText.GetComponent<Text>().text = "Primero empecemos con el enemigo más común:\nLa bacteria normal.";
    }
    public void PassPoint7()
    {
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, target2.position, 50);
        point2 = false;
        button6.SetActive(false);
        button7.SetActive(true);
        cuadroText.GetComponent<Text>().text = "La bateria normal tienen un ratio de aparición muy alto. Tienen 1 de vida y si están mucho tiempo presente pueden empezar a lastimarte.";
    }
}
