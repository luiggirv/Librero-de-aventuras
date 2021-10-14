using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public static bool isLoading = false;
    // Start is called before the first frame update
    public void NewGame()
    {
        SceneManager.LoadScene(12);
    }

    // Update is called once per frame
    public void LoadGame()
    {
        isLoading = true;
        SceneManager.LoadScene(3);
    }
    public void Regresar()
    {
        SceneManager.LoadScene(80);
    }
}
