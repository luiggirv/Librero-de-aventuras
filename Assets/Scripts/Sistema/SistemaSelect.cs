using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Respiratorio()
    {
        SceneManager.LoadScene(8);
    }
    public void Circulatorio()
    {

    }
    public void Nervioso()
    {

    }
    public void Regresar(){
        SceneManager.LoadScene(4);
    }
}
