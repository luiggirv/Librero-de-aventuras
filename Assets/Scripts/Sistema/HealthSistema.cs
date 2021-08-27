using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSistema : MonoBehaviour
{

    public int maxHealth;
    public static int currentHealth;
    public int internalHealth;
    public GameObject healthBar;
    public GameObject NotaFinal;
    public GameObject GameOverUI;
    public static bool GameIsPause = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        internalHealth = currentHealth;
        healthBar.GetComponent<Slider>().value = internalHealth;


        if (healthBar.GetComponent<Slider>().value == 0)
        {
            var clones = GameObject.FindGameObjectsWithTag("Virus");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            var clonesObjetos = GameObject.FindGameObjectsWithTag("Objeto");
            foreach (var clone in clonesObjetos)
            {
                Destroy(clone);
            }
            NotaFinal.GetComponent<Text>().text = "Perdiste toda tu vida.";
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }

    public void RegresarNivel()
    {
        currentHealth = 100;
        Time.timeScale = 1f;
        SceneManager.LoadScene(8);

    }

    public void RegresarMenu()
    {
        currentHealth = 100;
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }

}
