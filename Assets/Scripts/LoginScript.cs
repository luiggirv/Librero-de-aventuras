using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LootLocker.Requests;
using System;
using GameAuthoringAPI;

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

    public bool inicioSesion = false;

    public bool sesionInvitado = false;
    public GameObject ConfiguraciónLocalUI;

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


    void OnRegisterSuccess()
    {
        messageText.text = "¡Inicio de sesión exitoso!";
    }

    public void ingresarLogin()
    {
        sesionInvitado = false;
        CallLogin();
    }

    public void invitadoLogin()
    {
        //defaultConfiguration();
        sesionInvitado = true;

        if (!PlayerPrefs.HasKey("GUID"))
        {
           LoginUI.SetActive(false);
           CreateNickUI.SetActive(true);
        }
        else
        {
            LoginUI.SetActive(false);
            ConfiguraciónLocalUI.SetActive(true);
            //StartCoroutine(Cargando());
        }
    }

    public void regresarLogin()
    {
        LoginUI.SetActive(true);
        ConfiguraciónLocalUI.SetActive(false);
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
                if (sesionInvitado)
                {
                    CreateNickUI.SetActive(false);
                    ConfiguraciónLocalUI.SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene(80);
                }
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

    public void CallLogin()
    {
        Debug.Log("JBM: CallLogin ");
        Debug.Log("JBM: Login - " + emailInput.text);

        StartCoroutine(LibreroAventurasGameAuthoringAPIAdapter.Instance.Login(emailInput.text, passwordInput.text, ProcessGameStudentAfterAuthentication));
    }

    IEnumerator NotLogged()
    {
        /*
        WWWForm form = new WWWForm();
        form.AddField("name", emailInput.text);
        form.AddField("password", passwordInput.text);
        Debug.Log("JBM: Login - " + emailInput.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.username = emailInput.text;
            Debug.Log("Username: " + DBManager.username);
            firstMenu.SetActive(true);
            loginMenu.SetActive(false);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Debug.Log("Inicio de sesion fallido. Error #" + www.text);
            messageText.text = "NO SE PUDO INICIAR SESI?N";
            yield return new WaitForSeconds(5);
            messageText.text = "";
        }*/
        messageText.text = "No se pudo iniciar sesión. \nVerifique el correo y la contraseña ingresada y vuelva a intentarlo." ;
        yield return new WaitForSeconds(5f);
        messageText.text = "";
    }

    public void Return()
    {
        SceneManager.LoadScene("Register");
    }

    public void ProcessGameStudentAfterAuthentication(GameStudent gameStudent)
    {
        LibreroAventurasGameAuthoringAPIAdapter.student = (LibreroAventurasGameStudent)gameStudent;
        if (gameStudent != null)
        {
            inicioSesion = true;
            StartCoroutine(LibreroAventurasGameAuthoringAPIAdapter.Instance.GetStudentGameConfigs(
                gameStudent.Token, gameStudent.Username, LibreroAventurasGameAuthoringAPIAdapter.GAME_ID,
                ProcessStudentGameConfigs));
        }
        else
        {
            inicioSesion = false;
            Debug.Log("Usuario y password incorrectos");
            StartCoroutine("NotLogged");
        }
    }

    public void ProcessStudentGameConfigs(List<StudentGameSessionConfig> studentGameSessionConfigs)
    {
        Debug.Log("JBM: ProcessStudentGameConfigs ");

        int sgscIndex = 0, sgscCount = studentGameSessionConfigs.Count;
        foreach (LibreroAventurasStudentGameSessionConfig studentGameSessionConfig in studentGameSessionConfigs)
        {
            sgscIndex++;
            if (studentGameSessionConfig != null && sgscIndex == sgscCount)
            {
                for (int i = 0; i < studentGameSessionConfig.competences.Count; i++)
                {
                    if (studentGameSessionConfig.competences[i].Name.Contains("Sistemas internos de los seres humanos."))
                    {
                        if (studentGameSessionConfig.competences[i].IsActive)
                        {
                            Debug.Log("JBM Configuraci?n: Competence - " + studentGameSessionConfig.competences[i].Name + " is active. ");
                            for (int j = 0; j < studentGameSessionConfig.competences[i].competences.Count; j++)
                            {
                                if (studentGameSessionConfig.competences[i].competences[j].Name.Contains("Tutorial al entrar a la aventura"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        Debug.Log("JBM Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        PlayerPrefs.SetInt("TutorialSistemas", 1);
                                    }
                                    else
                                        PlayerPrefs.SetInt("TutorialSistemas", 0);
                                }
                                if (studentGameSessionConfig.competences[i].competences[j].Name.Equals("Sistema respiratorio"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        PlayerPrefs.SetInt("isRespiratorio", 1);
                                        Debug.Log("JBM Sub Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        for (int k = 0; k < studentGameSessionConfig.competences[i].competences[j].competences.Count; k++)
                                        {
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Pulm") &&
                                                studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("n izquierdo"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isPulmonIzq", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isPulmonIzq", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Pulm") &&
                                                studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("n derecho"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isPulmonDer", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isPulmonDer", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Tr") &&
                                                studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("quea"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isTraquea", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isTraquea", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Fosas nasales, laringe y faringe"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isFosas", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isFosas", 0);
                                            }
                                        }
                                    }

                                }
                                else
                                    PlayerPrefs.SetInt("isRespiratorio", 0);

                                if (studentGameSessionConfig.competences[i].competences[j].Name.Equals("Sistema nervioso"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        PlayerPrefs.SetInt("isNervioso", 1);
                                        Debug.Log("JBM Sub Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        for (int k = 0; k < studentGameSessionConfig.competences[i].competences[j].competences.Count; k++)
                                        {
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Enc") &&
                                                studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("falo"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isEncefalo", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isEncefalo", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Nervios"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isNervios", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isNervios", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("M") &&
                                                studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("dula espinal"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isMedula", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isMedula", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Ganglios"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isGanglios", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isGanglios", 0);
                                            }
                                        }
                                    }

                                }
                                else
                                    PlayerPrefs.SetInt("isNervioso", 0);

                                if (studentGameSessionConfig.competences[i].competences[j].Name.Equals("Sistema circulatorio"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        PlayerPrefs.SetInt("isCirculatorio", 1);
                                        Debug.Log("JBM Sub Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        for (int k = 0; k < studentGameSessionConfig.competences[i].competences[j].competences.Count; k++)
                                        {
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Arterias"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isArterias", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isArterias", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Venas"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isVenas", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isVenas", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Coraz") &&
                                                studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("n"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isCorazon", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isCorazon", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Capilares"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isCapilares", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isCapilares", 0);
                                            }
                                        }
                                    }

                                }
                                else
                                    PlayerPrefs.SetInt("isCirculatorio", 0);
                            }
                        }
                    }


                    if (studentGameSessionConfig.competences[i].Name.Contains("Propiedades de la materia, m") &&
                        studentGameSessionConfig.competences[i].Name.Contains("todo cient") &&
                        studentGameSessionConfig.competences[i].Name.Contains("fico y soluciones tecnol") &&
                        studentGameSessionConfig.competences[i].Name.Contains("gicas."))
                    {
                        if (studentGameSessionConfig.competences[i].IsActive)
                        {
                            Debug.Log("JBM Configuraci?n: Competence - " + studentGameSessionConfig.competences[i].Name + " is active. ");
                            for (int j = 0; j < studentGameSessionConfig.competences[i].competences.Count; j++)
                            {
                                if (studentGameSessionConfig.competences[i].competences[j].Name.Contains("Tutorial al entrar a la aventura"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        Debug.Log("JBM Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        PlayerPrefs.SetInt("TutorialMetodo", 1);
                                    }
                                    else
                                        PlayerPrefs.SetInt("TutorialMetodo", 0);
                                }
                                if (studentGameSessionConfig.competences[i].competences[j].Name.Contains("Mostrar las fases del m") &&
                                    studentGameSessionConfig.competences[i].competences[j].Name.Contains("todo cient") &&
                                    studentGameSessionConfig.competences[i].competences[j].Name.Contains("fico"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        Debug.Log("JBM Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        PlayerPrefs.SetInt("MostrarFases", 1);
                                    }
                                    else
                                        PlayerPrefs.SetInt("MostrarFases", 0);
                                }
                            }
                        }
                    }

                    if (studentGameSessionConfig.competences[i].Name.Contains("Ecosistemas y seres vivos.") )
                    {
                        if (studentGameSessionConfig.competences[i].IsActive)
                        {
                            Debug.Log("JBM Configuraci?n: Competence - " + studentGameSessionConfig.competences[i].Name + " is active. ");
                            for (int j = 0; j < studentGameSessionConfig.competences[i].competences.Count; j++)
                            {
                                if (studentGameSessionConfig.competences[i].competences[j].Name.Contains("Tutorial al entrar a la aventura"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        Debug.Log("JBM Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        PlayerPrefs.SetInt("TutorialEcosistemas", 1);
                                    }
                                    else
                                        PlayerPrefs.SetInt("TutorialEcosistemas", 0);
                                }
                                if (studentGameSessionConfig.competences[i].competences[j].Name.Contains("Bosque"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        Debug.Log("JBM Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        PlayerPrefs.SetInt("isBosque", 1);
                                    }
                                    else
                                        PlayerPrefs.SetInt("isBosque", 0);
                                }
                                if (studentGameSessionConfig.competences[i].competences[j].Name.Equals("Lago"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        PlayerPrefs.SetInt("isLago", 1);
                                        Debug.Log("JBM Sub Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        for (int k = 0; k < studentGameSessionConfig.competences[i].competences[j].competences.Count; k++)
                                        {
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Reciclaje"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isReciclaje", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isReciclaje", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Animales acuaticos"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isAcuaticos", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isAcuaticos", 0);
                                            }
                                        }
                                    }

                                }
                                else
                                    PlayerPrefs.SetInt("isLago", 0);

                                if (studentGameSessionConfig.competences[i].competences[j].Name.Equals("Montaña"))
                                {
                                    if (studentGameSessionConfig.competences[i].competences[j].IsActive)
                                    {
                                        PlayerPrefs.SetInt("isMontaña", 1);
                                        Debug.Log("JBM Sub Competence - " + studentGameSessionConfig.competences[i].competences[j].Name + " is active.");
                                        for (int k = 0; k < studentGameSessionConfig.competences[i].competences[j].competences.Count; k++)
                                        {
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Verano"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isVerano", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isVerano", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Otoño"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isOtoño", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isOtoño", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Invierno"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isInvierno", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isInvierno", 0);
                                            }
                                            if (studentGameSessionConfig.competences[i].competences[j].competences[k].Name.Contains("Primavera"))
                                            {
                                                if (studentGameSessionConfig.competences[i].competences[j].competences[k].IsActive)
                                                {
                                                    Debug.Log("JBM Sub sub competence - " + studentGameSessionConfig.competences[i].competences[j].competences[k].Name + " is active.");
                                                    PlayerPrefs.SetInt("isPrimavera", 1);
                                                }
                                                else
                                                    PlayerPrefs.SetInt("isPrimavera", 0);
                                            }
                                        }
                                    }

                                }
                                else
                                    PlayerPrefs.SetInt("isMontaña", 0);
                            }
                        }
                    }
                }
            }
        }

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

    public void defaultConfiguration()
    {
        PlayerPrefs.SetInt("TutorialSistemas", 1);
        PlayerPrefs.SetInt("isRespiratorio", 1);
        PlayerPrefs.SetInt("isPulmonIzq", 1);
        PlayerPrefs.SetInt("isPulmonDer", 1);
        PlayerPrefs.SetInt("isTraquea", 1);
        PlayerPrefs.SetInt("isFosas", 1);

        PlayerPrefs.SetInt("isNervioso", 1);
        PlayerPrefs.SetInt("isEncefalo", 1);
        PlayerPrefs.SetInt("isNervios", 1);
        PlayerPrefs.SetInt("isMedula", 0);
        PlayerPrefs.SetInt("isGanglios", 0);

        PlayerPrefs.SetInt("isCirculatorio", 1);
        PlayerPrefs.SetInt("isArterias", 0);
        PlayerPrefs.SetInt("isVenas", 1);
        PlayerPrefs.SetInt("isCorazon", 0);
        PlayerPrefs.SetInt("isCapilares", 0);

        PlayerPrefs.SetInt("TutorialMetodo", 1);
        PlayerPrefs.SetInt("MostrarFases", 1);

        PlayerPrefs.SetInt("TutorialEcosistemas", 1);
        PlayerPrefs.SetInt("isBosque", 1);

        PlayerPrefs.SetInt("isLago", 1);
        PlayerPrefs.SetInt("isReciclaje", 0);
        PlayerPrefs.SetInt("isAcuaticos", 1);

        PlayerPrefs.SetInt("isMontaña", 1);
        PlayerPrefs.SetInt("isVerano", 0);
        PlayerPrefs.SetInt("isOtoño", 0);
        PlayerPrefs.SetInt("isInvierno", 1);
        PlayerPrefs.SetInt("isPrimavera", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!RespiratorioToggle.GetComponent<Toggle>().isOn)
        {
            RespiratorioToggleSec1.GetComponent<Toggle>().interactable = false;
            RespiratorioToggleSec2.GetComponent<Toggle>().interactable = false;
            RespiratorioToggleSec3.GetComponent<Toggle>().interactable = false;
            RespiratorioToggleSec4.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            RespiratorioToggleSec1.GetComponent<Toggle>().interactable = true;
            RespiratorioToggleSec2.GetComponent<Toggle>().interactable = true;
            RespiratorioToggleSec3.GetComponent<Toggle>().interactable = true;
            RespiratorioToggleSec4.GetComponent<Toggle>().interactable = true;
        }

        if (!CirculatorioToggle.GetComponent<Toggle>().isOn)
        {
            CirculatorioToggleSec1.GetComponent<Toggle>().interactable = false;
            CirculatorioToggleSec2.GetComponent<Toggle>().interactable = false;
            CirculatorioToggleSec3.GetComponent<Toggle>().interactable = false;
            CirculatorioToggleSec4.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            CirculatorioToggleSec1.GetComponent<Toggle>().interactable = true;
            CirculatorioToggleSec2.GetComponent<Toggle>().interactable = true;
            CirculatorioToggleSec3.GetComponent<Toggle>().interactable = true;
            CirculatorioToggleSec4.GetComponent<Toggle>().interactable = true;
        }

        if (!NerviosoToggle.GetComponent<Toggle>().isOn)
        {
            NerviosoToggleSec1.GetComponent<Toggle>().interactable = false;
            NerviosoToggleSec2.GetComponent<Toggle>().interactable = false;
            NerviosoToggleSec3.GetComponent<Toggle>().interactable = false;
            NerviosoToggleSec4.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            NerviosoToggleSec1.GetComponent<Toggle>().interactable = true;
            NerviosoToggleSec2.GetComponent<Toggle>().interactable = true;
            NerviosoToggleSec3.GetComponent<Toggle>().interactable = true;
            NerviosoToggleSec4.GetComponent<Toggle>().interactable = true;
        }

        if (!LagoToggle.GetComponent<Toggle>().isOn)
        {
            LagoToggleSec1.GetComponent<Toggle>().interactable = false;
            LagoToggleSec2.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            LagoToggleSec1.GetComponent<Toggle>().interactable = true;
            LagoToggleSec2.GetComponent<Toggle>().interactable = true;
        }

        if (!MontañaToggle.GetComponent<Toggle>().isOn)
        {
            MontañaToggleSec1.GetComponent<Toggle>().interactable = false;
            MontañaToggleSec2.GetComponent<Toggle>().interactable = false;
            MontañaToggleSec3.GetComponent<Toggle>().interactable = false;
            MontañaToggleSec4.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            MontañaToggleSec1.GetComponent<Toggle>().interactable = true;
            MontañaToggleSec2.GetComponent<Toggle>().interactable = true;
            MontañaToggleSec3.GetComponent<Toggle>().interactable = true;
            MontañaToggleSec4.GetComponent<Toggle>().interactable = true;
        }
    }

    public void ingresarConfiguracion()
    {
        //Aventura 1
        if (TutorialAventura1Toggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("TutorialSistemas", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TutorialSistemas", 0);
        }

        //Sistema respiratorio
        if (RespiratorioToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isRespiratorio", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isRespiratorio", 0);
        }

        if (RespiratorioToggleSec1.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isPulmonIzq", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isPulmonIzq", 0);
        }
        if (RespiratorioToggleSec2.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isPulmonDer", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isPulmonDer", 0);
        }
        if (RespiratorioToggleSec3.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isTraquea", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isTraquea", 0);
        }
        if (RespiratorioToggleSec4.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isFosas", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isFosas", 0);
        }

        //Sistema nervioso
        if (NerviosoToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isNervioso", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isNervioso", 0);
        }

        if (NerviosoToggleSec1.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isEncefalo", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isEncefalo", 0);
        }
        if (NerviosoToggleSec2.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isNervios", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isNervios", 0);
        }
        if (NerviosoToggleSec3.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isMedula", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isMedula", 0);
        }
        if (NerviosoToggleSec4.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isGanglios", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isGanglios", 0);
        }

        //Sistema circulatorio
        if (CirculatorioToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isCirculatorio", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isCirculatorio", 0);
        }

        if (CirculatorioToggleSec1.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isArterias", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isArterias", 0);
        }
        if (CirculatorioToggleSec2.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isVenas", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isVenas", 0);
        }
        if (CirculatorioToggleSec3.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isCorazon", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isCorazon", 0);
        }
        if (CirculatorioToggleSec4.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isCapilares", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isCapilares", 0);
        }

        //Aventura 3
        if (TutorialAventura3Toggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("TutorialMetodo", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TutorialMetodo", 0);
        }
        //Fases del metodo científico
        if (MetodoToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("MostrarFases", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MostrarFases", 0);
        }

        //Aventura 2
        if (TutorialAventura2Toggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("TutorialEcosistemas", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TutorialEcosistemas", 0);
        }

        //Bosque
        if (BosqueToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isBosque", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isBosque", 0);
        }


        //Lago
        if (LagoToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isLago", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isLago", 0);
        }
        if (LagoToggleSec1.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isReciclaje", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isReciclaje", 0);
        }
        if (LagoToggleSec2.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isAcuaticos", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isAcuaticos", 0);
        }


        //Montaña
        if (MontañaToggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isMontaña", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isMontaña", 0);
        }
        if (MontañaToggleSec1.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isVerano", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isVerano", 0);
        }
        if (MontañaToggleSec2.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isInvierno", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isInvierno", 0);
        }
        if (MontañaToggleSec3.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isPrimavera", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isPrimavera", 0);
        }
        if (MontañaToggleSec4.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("isOtoño", 1);
        }
        else
        {
            PlayerPrefs.SetInt("isOtoño", 0);
        }

        StartCoroutine(Cargando());

    }


}
