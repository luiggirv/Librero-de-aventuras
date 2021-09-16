using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public Text messageText;

    void OnRegisterSuccess()
    {
        messageText.text = "¡Inicio de sesión exitoso!";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
