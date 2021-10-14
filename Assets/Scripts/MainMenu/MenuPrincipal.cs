using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LootLocker.Requests;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject principalUI;
    public GameObject seleccionarUI;
    public GameObject configuracionUI;
    public InputField PlayerNameInputField;
    public GameObject nameText;
    public GameObject idText;

    public void Siguiente()
    {
        principalUI.SetActive(false);
        seleccionarUI.SetActive(true);
    }

    public void abrirConfiguracion()
    {
        configuracionUI.SetActive(true);
    }
    public void cerrarConfiguracion()
    {
        configuracionUI.SetActive(false);
    }
    
    public void guardarConfiguracion()
    {
        if (PlayerPrefs.HasKey("GUID"))
        {
            string ID = PlayerPrefs.GetString("GUID");
            LootLockerSDKManager.StartSession(ID, (response) =>
            {
                if (response.success)
                {
                    if (PlayerNameInputField.text == null || PlayerNameInputField.text == "")
                    {
                        Debug.Log("Sin cambios");
                    }
                    else
                    {
                        LootLockerSDKManager.SetPlayerName(PlayerNameInputField.text, null);
                        PlayerPrefs.SetString("NameGUID", PlayerNameInputField.text);
                        Debug.Log("Cambiando nombre...");
                        LootLockerSDKManager.GetPlayerName((response) => {
                        if (response.success)
                        {
                            Debug.Log("Nombre cambiado: " + PlayerNameInputField.text);
                            nameText.GetComponent<Text>().text = "Nombre: " + PlayerNameInputField.text;
                        }
                        else
                        {
                            Debug.Log("Error al obtener el nombre");
                        }
                    });
                    }
                }
                else
                {
                    Debug.Log("Failed" + response.Error);
                }
            });
        }
        configuracionUI.SetActive(false);
    }

    public void Ecosistema()
    {
        SceneManager.LoadScene(1);
    }

    public void Sistema()
    {
        SceneManager.LoadScene(4);
    }

    public void Metodo()
    {
        SceneManager.LoadScene(19);
    }

    public void Regresar()
    {
        seleccionarUI.SetActive(false);
        principalUI.SetActive(true);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("GUID"))
        {
            string ID = PlayerPrefs.GetString("GUID");
            string nombre = PlayerPrefs.GetString("NameGUID");
            idText.GetComponent<Text>().text = "ID: " + ID;
            nameText.GetComponent<Text>().text = "Nombre: " + nombre;
            //LootLockerSDKManager.StartSession(ID, (response) =>
            //{
            //    if (response.success)
            //    {
            //        LootLockerSDKManager.GetPlayerName((response) => {
            //            if (response.success)
            //            {
            //                Debug.Log("Successfully retrieved player name: " + response.name);
            //                nameText.GetComponent<Text>().text = "Nombre: " + response.name;
            //            }
            //            else
            //            {
            //                Debug.Log("Error getting player name");
            //            }
            //        });
            //    }
            //    else
            //    {
            //        Debug.Log("Failed" + response.Error);
            //    }
            //});
        }

    }
}
