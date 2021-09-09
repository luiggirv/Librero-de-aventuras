using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTDScript : MonoBehaviour
{
    public GameObject Parte1;
    public GameObject Parte2;
    public GameObject Parte3;
    public GameObject Parte4;
    public GameObject Parte5;
    public GameObject Parte6;

    public void PasarParte2()
    {
        Parte1.SetActive(false);
        Parte2.SetActive(true);
    }
    public void PasarParte3()
    {
        Parte2.SetActive(false);
        Parte3.SetActive(true);
    }
    public void PasarParte4()
    {
        Parte3.SetActive(false);
        Parte4.SetActive(true);
    }
    public void PasarParte5()
    {
        Parte4.SetActive(false);
        Parte5.SetActive(true);
    }
    public void PasarParte6()
    {
        Parte5.SetActive(false);
        Parte6.SetActive(true);
    }
    public void RetrocederAParte1()
    {
        Parte2.SetActive(false);
        Parte1.SetActive(true);
    }
    public void RetrocederAParte2()
    {
        Parte3.SetActive(false);
        Parte2.SetActive(true);
    }
    public void RetrocederAParte3()
    {
        Parte4.SetActive(false);
        Parte3.SetActive(true);
    }
    public void RetrocederAParte4()
    {
        Parte5.SetActive(false);
        Parte4.SetActive(true);
    }
    public void RetrocederAParte5()
    {
        Parte6.SetActive(false);
        Parte5.SetActive(true);
    }
}
