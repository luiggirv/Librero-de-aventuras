using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosSpawn : MonoBehaviour
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
                whereToSpawn = new Vector2(randX, randY);  
                GameObject resultVirus = virusArray[Random.Range(0, virusArray.Length)];
                Instantiate(resultVirus, whereToSpawn, Quaternion.identity);
                numberObjectGenerate += 1;
            //}
        }

    }
}
