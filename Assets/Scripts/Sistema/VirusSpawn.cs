using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawn : MonoBehaviour
{
    public GameObject[] virusArray;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 1f;
    public float nextSpawn = 0.0f;
    public static int numberVirusGenerate;

    void Start()
    {
        numberVirusGenerate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (LugarGlobal.numVirusNecesarios > numberVirusGenerate)
            {
                nextSpawn = Time.time + spawnRate;
                randX = Random.Range(-3.4f, 3.4f);
                randY = Random.Range(-3.4f, 3.4f);
                whereToSpawn = new Vector2(randX, randY);
                GameObject resultVirus = virusArray[Random.Range(0, virusArray.Length)];
                Instantiate(resultVirus, whereToSpawn, Quaternion.identity);
                numberVirusGenerate += 1;
            }
        }

    }
}
