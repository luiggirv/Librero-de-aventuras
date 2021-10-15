using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple enemy health system.
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    public int max;
    public int current;
    public int damage = 35;

    public GameObject explosion;

    private void Awake()
    {
        current = max;
    }
    
    public void DamageEnemy(int amount)
    {
        current -= amount;
        if(current <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    void OnMouseDown()
    {
        current -= damage;
        if (current <= 0)
        {
            Death();
        }
    }
}
