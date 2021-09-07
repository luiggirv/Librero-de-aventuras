using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLevel : MonoBehaviour
{
    public int levelNumber;              //The number of the level
    public bool alwaysUnlocked;             //The level is always/not always unlocked
    public GameObject Puntuacion;
    public GameObject NVirus;
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
                case 101:
                case 102:
                case 103:
                case 104:
                case 105:
                case 106:
                    //Loop trought the save data for level 1-4
                    for (int i = 101; i < levelNumber; i++)
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
                case 201:
                case 202:
                case 203:
                case 204:
                case 205:
                case 206:
                    //Loop trought the save data for level 1-4
                    for (int i = 201; i < levelNumber; i++)
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
                case 301:
                case 302:
                case 303:
                case 304:
                case 305:
                case 306:
                    //Loop trought the save data for level 1-4
                    for (int i = 301; i < levelNumber; i++)
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

                case 401:
                case 402:
                case 403:
                case 404:
                case 405:
                case 406:
                    //Loop trought the save data for level 1-4
                    for (int i = 301; i < levelNumber; i++)
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
        PlayerPrefs.SetInt(levelNumber.ToString() + "b", 0);
        PlayerPrefs.Save();
    }
    //Unlocks this button
    void Unlocked()
    {
        islocked = false;
        this.GetComponent<Button>().interactable = true;
        Lock.SetActive(false);
        Puntuacion.GetComponent<Text>().text = PlayerPrefs.GetInt(levelNumber.ToString() + "a").ToString();
        NVirus.GetComponent<Text>().text = PlayerPrefs.GetInt(levelNumber.ToString() + "b").ToString();
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
