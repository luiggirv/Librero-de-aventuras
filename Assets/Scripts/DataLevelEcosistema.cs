using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLevelEcosistema : MonoBehaviour
{
    public int levelNumber;              //El número del nivel
    public bool alwaysUnlocked;             //Si el nivel esta desbloqueado siempre o no
    public GameObject Puntuacion;
    public GameObject Lock;
    bool islocked;                          //Bandera de bloqueado

    void Start()
    {
        if (!PlayerPrefs.HasKey(levelNumber.ToString()+"a"))
        {
            CreateData();
        }
        //Si el nivel siempre está desbloqueado, entonces se usa Unlocked()
        if (alwaysUnlocked)
            Unlocked();
        //Si no es el caso, el nivel estará bloqueado hasta que el anterior esté desbloqueado y con datos creados
        else
        {
            switch (levelNumber)
            {

                case 401:
                case 402:
                case 403:
                case 404:
                case 405:
                case 406:
                    //Loop para verificar si los niveles anteriores al seleccionado están desbloqueados y con data
                    for (int i = 401; i < levelNumber; i++)
                    {
                        //Si alguno de los niveles anteriores no está completo, bloquear nivel
                        if (PlayerPrefs.GetInt(i.ToString() + "a") == 0 || !PlayerPrefs.HasKey(i.ToString() + "a"))
                        {
                            Locked();
                            return;
                        }
                    }
                    //Si los niveles anteriores están desbloqueados y con data, se desbloquea
                    Unlocked();
                    break;
                case 501:
                case 502:
                case 503:
                case 504:
                case 505:
                case 506:
                    //Loop para verificar si los niveles anteriores al seleccionado están desbloqueados y con data
                    for (int i = 501; i < levelNumber; i++)
                    {
                        //Si alguno de los niveles anteriores no está completo, bloquear nivel
                        if (PlayerPrefs.GetInt(i.ToString() + "a") == 0 || !PlayerPrefs.HasKey(i.ToString() + "a"))
                        {
                            Locked();
                            return;
                        }
                    }
                    //Si los niveles anteriores están desbloqueados y con data, se desbloquea
                    Unlocked();
                    break;
            }
        }
    }

    //Se crea data con valor 0 para el nivel
    void CreateData()
    {
        PlayerPrefs.SetInt(levelNumber.ToString()+"a", 0);
        PlayerPrefs.Save();
    }
    //Desbloquea el nivel
    void Unlocked()
    {
        islocked = false;
        this.GetComponent<Button>().interactable = true;
        Lock.SetActive(false);
        Puntuacion.GetComponent<Text>().text = PlayerPrefs.GetInt(levelNumber.ToString() + "a").ToString();
    }
    //Bloquea el nivel
    void Locked()
    {
        islocked = true;
        Lock.SetActive(false);
        this.GetComponent<Button>().interactable = false;
    }

}
