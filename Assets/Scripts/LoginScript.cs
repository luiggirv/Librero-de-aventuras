using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LootLocker.Requests;
using System;

public class LoginScript : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public Text messageText;

    public InputField PlayerNameInputField;
    public GameObject CreatePlayerButton;
    Guid currentDeviceID;

    public GameObject LoginUI;
    public GameObject CreateNickUI;
    public GameObject cargandoUI;

    void OnRegisterSuccess()
    {
        messageText.text = "¡Inicio de sesión exitoso!";
    }

    public void ingresarLogin()
    {
        if (!PlayerPrefs.HasKey("GUID"))
        {
            LoginUI.SetActive(false);
            CreateNickUI.SetActive(true);
        }
        else
        {
            StartCoroutine(Cargando());
        }
    }

    public void setNickname()
    {
        if (PlayerNameInputField.text == null || PlayerNameInputField.text == "")
        {
            messageText.text = "El nombre no puede estar vacío. Ingresa un nombre.";
        }
        else if (PlayerNameInputField.text.Length > 12)
        {
            messageText.text = "El nombre debe tener un máximo de 12 caracteres.";
        }
        else
        {
            CreatePlayer();
            SceneManager.LoadScene(80);
        }
    }

    public void CreatePlayer()
    {
        currentDeviceID = Guid.NewGuid();
        PlayerPrefs.SetString("GUID", currentDeviceID.ToString());

        LootLockerSDKManager.StartSession(currentDeviceID.ToString(), (response) =>
        {
            if (response.success)
            {
                LootLockerSDKManager.SetPlayerName(PlayerNameInputField.text, null);
                PlayerPrefs.SetString("NameGUID", PlayerNameInputField.text);
            }
            else
            {
                messageText.GetComponent<Text>().text = "Hubo un error. Verifica la conexión a internet del dispositivo.";
                Debug.Log("Failed" + response.Error);
            }
        });
    }

    public IEnumerator Cargando()
    {
        cargandoUI.SetActive(true);
        yield return new WaitForSeconds(2);
        cargandoUI.SetActive(false);
        SceneManager.LoadScene(80);
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
