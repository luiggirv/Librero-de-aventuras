using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelulaSpawn : MonoBehaviour
{
    public GameObject[] virusArray;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate;
    public float nextSpawn;
    int numberObjectGenerate;

    void Start()
    {
        //numberVirusGenerate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawn)
        {
            //if (numberObjectGenerate < 15)
            //{
            nextSpawn = Time.timeSinceLevelLoad + spawnRate;
            randX = Random.Range(-3.4f, 3.4f);
            randY = Random.Range(-2.8f, 2.8f);
            whereToSpawn = Camera.main.ViewportToWorldPoint(new Vector2(1.1f, Random.Range(0.2f, 0.8f)));
            GameObject resultVirus = virusArray[Random.Range(0, virusArray.Length)];
            Instantiate(resultVirus, whereToSpawn, Quaternion.identity);
            numberObjectGenerate += 1;
            //}
        }

    }
}
