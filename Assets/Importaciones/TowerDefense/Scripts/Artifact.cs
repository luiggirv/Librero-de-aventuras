using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds and manages the information about the Artifact's health and provides functions to damage and restore it's health.
/// </summary>
public class Artifact : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public int bleed;
    public GameObject audioSource;
    public GameObject sonidoCorral;
    float timer;
    int frutasTomadas;

    public GameObject player;

    void Awake()
    {
        health = maxHealth;
        timer = Time.time + 1;
    }

    void Update()
    {
        if(Time.time > timer)
        {
            health -= bleed;
            timer = Time.time + 1;
        }

        if(health <= 0)
        {
            health = 0;
        }
    }
    public void Damage(int amount)
    {
        health -= amount;
        sonidoCorral.GetComponent<AudioSource>().Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.GetComponent<PlayerBackpack>() != null)
        //{
        //    if(collision.GetComponent<PlayerBackpack>().current != 0)
        //    {
        //        audioSource.Play();
        //    }
        //    health += collision.GetComponent<PlayerBackpack>().TakeFruits();
        //    if(health > maxHealth)
        //    {
        //        health = maxHealth;
        //    }
        //}
    }

    void OnMouseDown()
    {
        if (player.GetComponent<PlayerBackpack>() != null)
        {
            if (player.GetComponent<PlayerBackpack>().current != 0)
            {
                audioSource.GetComponent<AudioSource>().Play();
            }
            frutasTomadas = player.GetComponent<PlayerBackpack>().TakeFruits();
            health += frutasTomadas;
            ScoreGlobalTower.ScoreCount += frutasTomadas;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }

    public void eatFruit()
    {
        frutasTomadas = player.GetComponent<PlayerBackpack>().TakeFruits();
        health += frutasTomadas;
        ScoreGlobalTower.ScoreCount += frutasTomadas;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
