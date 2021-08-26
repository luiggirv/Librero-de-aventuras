using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaSelect : MonoBehaviour
{
    public void Bosque()
    {
        SceneManager.LoadScene(15);
    }
    
    public void Lago()
    {
        SceneManager.LoadScene(14);
    }

    public void Montaña()
    {
        SceneManager.LoadScene(13);
    }
    public void Regresar()
    {
        SceneManager.LoadScene(1);
    }
}
