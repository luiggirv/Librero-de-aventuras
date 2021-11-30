using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LootLocker.Requests;

public class MenuPrincipal : MonoBehaviour
{

    public GameObject Aventura1;
    public GameObject Aventura2;
    public GameObject Aventura3;

    public GameObject principalUI;
    public GameObject seleccionarUI;
    public GameObject configuracionUI;
    public InputField PlayerNameInputField;
    public GameObject nameText;
    public GameObject idText;
    public GameObject messageText;
    public GameObject confirmacionUI;
    public GameObject ListaUI;

    public GameObject TutorialAventura1Toggle;
    public GameObject RespiratorioToggle;
    public GameObject RespiratorioToggleSec1;
    public GameObject RespiratorioToggleSec2;
    public GameObject RespiratorioToggleSec3;
    public GameObject RespiratorioToggleSec4;
    public GameObject CirculatorioToggle;
    public GameObject CirculatorioToggleSec1;
    public GameObject CirculatorioToggleSec2;
    public GameObject CirculatorioToggleSec3;
    public GameObject CirculatorioToggleSec4;
    public GameObject NerviosoToggle;
    public GameObject NerviosoToggleSec1;
    public GameObject NerviosoToggleSec2;
    public GameObject NerviosoToggleSec3;
    public GameObject NerviosoToggleSec4;

    public GameObject TutorialAventura2Toggle;
    public GameObject BosqueToggle;
    public GameObject LagoToggle;
    public GameObject LagoToggleSec1;
    public GameObject LagoToggleSec2;
    public GameObject MontañaToggle;
    public GameObject MontañaToggleSec1;
    public GameObject MontañaToggleSec2;
    public GameObject MontañaToggleSec3;
    public GameObject MontañaToggleSec4;

    public GameObject TutorialAventura3Toggle;
    public GameObject MetodoToggle;
    public void Siguiente()
    {
        principalUI.SetActive(false);
        seleccionarUI.SetActive(true);
    }

    public void abrirConfiguracion()
    {
        configuracionUI.SetActive(true);
    }

    public void abrirListaConfiguracion()
    {
        configuracionUI.SetActive(false);
        listarConfiguracion();
        ListaUI.SetActive(true);
    }
    public void regresarListaConfiguracion()
    {
        configuracionUI.SetActive(true);
        ListaUI.SetActive(false);
    }
    public void cerrarConfiguracion()
    {
        messageText.GetComponent<Text>().text = "";
        configuracionUI.SetActive(false);
    }

    public void abrirConfirmacion()
    {
        confirmacionUI.SetActive(true);
    }

    public void cerrarConfirmacion()
    {
        confirmacionUI.SetActive(false);
    }

    public void cerrarJuego()
    {
        SceneManager.LoadScene(0);
    }
    
    public void guardarConfiguracion()
    {
        if (PlayerNameInputField.text == null || PlayerNameInputField.text == "")
        {
            messageText.GetComponent<Text>().text = "El nombre no puede estar vacío. Ingresa un nombre.";
        }
        else if (PlayerNameInputField.text.Length > 12)
        {
            messageText.GetComponent<Text>().text = "El nombre debe tener un máximo de 12 caracteres.";
        }
        else if (PlayerPrefs.HasKey("GUID"))
        {
            string ID = PlayerPrefs.GetString("GUID");
            LootLockerSDKManager.StartSession(ID, (response) =>
            {
                if (response.success)
                {
                   LootLockerSDKManager.SetPlayerName(PlayerNameInputField.text, null);
                   PlayerPrefs.SetString("NameGUID", PlayerNameInputField.text);
                   //Debug.Log("Cambiando nombre...");
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
                   messageText.GetComponent<Text>().text = "";
                   configuracionUI.SetActive(false);
                }
                else
                {
                    messageText.GetComponent<Text>().text = "Hubo un error. Verifica la conexión a internet del dispositivo.";
                    Debug.Log("Failed" + response.Error);
                }
            });
        }
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
        Application.targetFrameRate = 60;
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
        if (PlayerPrefs.GetInt("isRespiratorio") == 0 && PlayerPrefs.GetInt("isNervioso") == 0 && PlayerPrefs.GetInt("isCirculatorio") == 0)
        {
            Aventura1.GetComponent<Button>().interactable = false;
        }
        else
        {
            Aventura1.GetComponent<Button>().interactable = true;
        }

        if (PlayerPrefs.GetInt("isLago") == 0 && PlayerPrefs.GetInt("isMontaña") == 0 && PlayerPrefs.GetInt("isBosque") == 0)
        {
            Aventura2.GetComponent<Button>().interactable = false;
        }
        else
        {
            Aventura2.GetComponent<Button>().interactable = true;
        }

        if (PlayerPrefs.GetInt("MostrarFases") == 0)
        {
            Aventura3.GetComponent<Button>().interactable = false;
        }
        else
        {
            Aventura3.GetComponent<Button>().interactable = true;
        }
    }

    public void listarConfiguracion()
    {
        RespiratorioToggleSec1.GetComponent<Toggle>().interactable = false;
        RespiratorioToggleSec2.GetComponent<Toggle>().interactable = false;
        RespiratorioToggleSec3.GetComponent<Toggle>().interactable = false;
        RespiratorioToggleSec4.GetComponent<Toggle>().interactable = false;

        CirculatorioToggleSec1.GetComponent<Toggle>().interactable = false;
        CirculatorioToggleSec2.GetComponent<Toggle>().interactable = false;
        CirculatorioToggleSec3.GetComponent<Toggle>().interactable = false;
        CirculatorioToggleSec4.GetComponent<Toggle>().interactable = false;

        NerviosoToggleSec1.GetComponent<Toggle>().interactable = false;
        NerviosoToggleSec2.GetComponent<Toggle>().interactable = false;
        NerviosoToggleSec3.GetComponent<Toggle>().interactable = false;
        NerviosoToggleSec4.GetComponent<Toggle>().interactable = false;

        BosqueToggle.GetComponent<Toggle>().interactable = false;
        LagoToggle.GetComponent<Toggle>().interactable = false;
        MontañaToggle.GetComponent<Toggle>().interactable = false;

        LagoToggleSec1.GetComponent<Toggle>().interactable = false;
        LagoToggleSec2.GetComponent<Toggle>().interactable = false;

        MontañaToggleSec1.GetComponent<Toggle>().interactable = false;
        MontañaToggleSec2.GetComponent<Toggle>().interactable = false;
        MontañaToggleSec3.GetComponent<Toggle>().interactable = false;
        MontañaToggleSec4.GetComponent<Toggle>().interactable = false;

        TutorialAventura1Toggle.GetComponent<Toggle>().interactable = false;
        TutorialAventura2Toggle.GetComponent<Toggle>().interactable = false;
        TutorialAventura3Toggle.GetComponent<Toggle>().interactable = false;
        RespiratorioToggle.GetComponent<Toggle>().interactable = false;
        NerviosoToggle.GetComponent<Toggle>().interactable = false;
        CirculatorioToggle.GetComponent<Toggle>().interactable = false;
        MetodoToggle.GetComponent<Toggle>().interactable = false;


        //Aventura 1
        if (PlayerPrefs.GetInt("TutorialSistemas") == 1)
        {
            TutorialAventura1Toggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            TutorialAventura1Toggle.GetComponent<Toggle>().isOn = false;
        }

        //Sistema respiratorio
        if (PlayerPrefs.GetInt("isRespiratorio") == 1)
        {
            RespiratorioToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            RespiratorioToggle.GetComponent<Toggle>().isOn = false;
        }

        if (PlayerPrefs.GetInt("isPulmonIzq") == 1)
        {
            RespiratorioToggleSec1.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            RespiratorioToggleSec1.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isPulmonDer") == 1)
        {
            RespiratorioToggleSec2.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            RespiratorioToggleSec2.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isTraquea") == 1)
        {
            RespiratorioToggleSec3.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            RespiratorioToggleSec3.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isFosas") == 1)
        {
            RespiratorioToggleSec4.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            RespiratorioToggleSec4.GetComponent<Toggle>().isOn = false;
        }

        //Sistema nervioso
        if (PlayerPrefs.GetInt("isNervioso") == 1)
        {
            NerviosoToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            NerviosoToggle.GetComponent<Toggle>().isOn = false;
        }

        if (PlayerPrefs.GetInt("isEncefalo") == 1)
        {
            NerviosoToggleSec1.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            NerviosoToggleSec1.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isNervios") == 1)
        {
            NerviosoToggleSec2.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            NerviosoToggleSec2.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isMedula") == 1)
        {
            NerviosoToggleSec3.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            NerviosoToggleSec3.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isGanglios") == 1)
        {
            NerviosoToggleSec4.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            NerviosoToggleSec4.GetComponent<Toggle>().isOn = false;
        }

        //Sistema circulatorio
        if (PlayerPrefs.GetInt("isCirculatorio")==1)
        {
            CirculatorioToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            CirculatorioToggle.GetComponent<Toggle>().isOn = false;
        }

        if (PlayerPrefs.GetInt("isArterias") == 1)
        {
            CirculatorioToggleSec1.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            CirculatorioToggleSec1.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isVenas") == 1)
        {
            CirculatorioToggleSec2.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            CirculatorioToggleSec2.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isCorazon") == 1)
        {
            CirculatorioToggleSec3.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            CirculatorioToggleSec3.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isCapilares") == 1)
        {
            CirculatorioToggleSec4.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            CirculatorioToggleSec4.GetComponent<Toggle>().isOn = false;
        }

        //Aventura 3
        if (PlayerPrefs.GetInt("TutorialMetodo") == 1)
        {
            TutorialAventura3Toggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            TutorialAventura3Toggle.GetComponent<Toggle>().isOn = false;
        }
        //Fases del metodo científico
        if (PlayerPrefs.GetInt("MostrarFases") == 1 )
        {
            MetodoToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            MetodoToggle.GetComponent<Toggle>().isOn = false;
        }

        //Aventura 2
        if (PlayerPrefs.GetInt("TutorialEcosistemas") == 1)
        {
            TutorialAventura2Toggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            TutorialAventura2Toggle.GetComponent<Toggle>().isOn = false;
        }

        //Bosque
        if (PlayerPrefs.GetInt("isBosque") == 1)
        {
            BosqueToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            BosqueToggle.GetComponent<Toggle>().isOn = false;
        }


        //Lago
        if (PlayerPrefs.GetInt("isLago") == 1)
        {
            LagoToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            LagoToggle.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isReciclaje") ==1)
        {
            LagoToggleSec1.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            LagoToggleSec1.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isAcuaticos") == 1)
        {
            LagoToggleSec2.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            LagoToggleSec2.GetComponent<Toggle>().isOn = false;
        }


        //Montaña
        if (PlayerPrefs.GetInt("isMontaña") == 1)
        {
            MontañaToggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            MontañaToggle.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isVerano") == 1)
        {
            MontañaToggleSec1.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            MontañaToggleSec1.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isInvierno") == 1)
        {
            MontañaToggleSec2.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            MontañaToggleSec2.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isPrimavera") == 1)
        {
            MontañaToggleSec3.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            MontañaToggleSec3.GetComponent<Toggle>().isOn = false;
        }
        if (PlayerPrefs.GetInt("isOtoño") == 1)
        {
            MontañaToggleSec4.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            MontañaToggleSec4.GetComponent<Toggle>().isOn = false;
        }
    }

}
