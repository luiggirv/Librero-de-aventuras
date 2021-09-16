using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCatch : MonoBehaviour
{
    public GameObject instruccionTutorial1;
    public GameObject instruccionTutorial2;
    public GameObject instruccionTutorial3;
    public GameObject instruccionTutorial4;
    public GameObject continueButton;

    public void SiguientePaso2()
    {
        instruccionTutorial1.SetActive(false);
        instruccionTutorial2.SetActive(true);
    }

    public void AnteriorPaso2()
    {
        instruccionTutorial1.SetActive(true);
        instruccionTutorial2.SetActive(false);
    }
    public void SiguientePaso3()
    {
        instruccionTutorial2.SetActive(false);
        instruccionTutorial3.SetActive(true);
    }

    public void AnteriorPaso3()
    {
        instruccionTutorial2.SetActive(true);
        instruccionTutorial3.SetActive(false);
    }
    public void SiguientePaso4()
    {
        instruccionTutorial3.SetActive(false);
        instruccionTutorial4.SetActive(true);
        continueButton.SetActive(true);
    }

    public void AnteriorPaso4()
    {
        instruccionTutorial3.SetActive(true);
        instruccionTutorial4.SetActive(false);
        continueButton.SetActive(false);
    }
    public void Continuar()
    {
        instruccionTutorial4.SetActive(false);
    }
}
