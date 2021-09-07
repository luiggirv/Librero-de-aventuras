using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLevelEcosistema : MonoBehaviour
{
    public int levelNumber;              //The number of the level
    public bool alwaysUnlocked;             //The level is always/not always unlocked
    public GameObject Puntuacion;
    public GameObject Lock;
    bool islocked;                          //The level is locked/unlocked

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(levelNumber.ToString()+"a"))
        {
            CreateData();
        }
        //If the level is always unlocked, unlock it
        if (alwaysUnlocked)
            Unlocked();
        //If the level is not always unlocked, it means the level id is between 5 and 8
        else
        {
            switch (levelNumber)
            {

                case 401:
                case 402:
                case 403:
                case 404:
                case 405:
                case 406:
                    //Loop trought the save data for level 1-4
                    for (int i = 401; i < levelNumber; i++)
                    {
                        //If a level is not completed, lock this level
                        if (PlayerPrefs.GetInt(i.ToString() + "a") == 0 || !PlayerPrefs.HasKey(i.ToString() + "a"))
                        {
                            Locked();
                            return;
                        }
                    }
                    //If every level between 1 and 4 is completed, unlock this
                    Unlocked();
                    break;
            }
        }
    }

    //Creates a save data for this level
    void CreateData()
    {
        PlayerPrefs.SetInt(levelNumber.ToString()+"a", 0);
        PlayerPrefs.Save();
    }
    //Unlocks this button
    void Unlocked()
    {
        islocked = false;
        this.GetComponent<Button>().interactable = true;
        Lock.SetActive(false);
        Puntuacion.GetComponent<Text>().text = PlayerPrefs.GetInt(levelNumber.ToString() + "a").ToString();
    }
    //Locks this button
    void Locked()
    {
        islocked = true;
        Lock.SetActive(false);
        this.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
