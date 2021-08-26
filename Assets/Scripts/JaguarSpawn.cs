using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaguarSpawn : MonoBehaviour
{
    public GameObject jaguarUI;
    public float respawnTime = 9f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(jaguarWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(jaguarUI) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 4, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator jaguarWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

    void Update()
    {
        
    }
}
