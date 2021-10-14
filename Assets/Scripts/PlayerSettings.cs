using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using System;

public class PlayerSettings : MonoBehaviour
{
    public InputField PlayerNameInputField;
    public GameObject CreatePlayerButton;
    Guid currentDeviceID;

    public void CreatePlayer()
    {
        currentDeviceID = Guid.NewGuid();
        PlayerPrefs.SetString("GUID", currentDeviceID.ToString());

        LootLockerSDKManager.StartSession(currentDeviceID.ToString(), (response) =>
         {
             if (response.success)
             {
                 LootLockerSDKManager.SetPlayerName(PlayerNameInputField.text, null);
                 Debug.Log("Sucess");
             }
             else
             {
                 Debug.Log("Failed" + response.Error);
             }
         });
    }

    public void EditNamePlayer()
    {
        if (PlayerPrefs.HasKey("GUID"))
        {
            string ID = PlayerPrefs.GetString("GUID");
            LootLockerSDKManager.StartSession(ID, (response) =>
            {
                if (response.success)
                {
                    if (PlayerNameInputField.text == null)
                    {
                        Debug.Log("No Change");
                    }
                    else
                    {
                        LootLockerSDKManager.SetPlayerName(PlayerNameInputField.text, null);
                        Debug.Log("Sucess");
                    }
                }
                else
                {
                    Debug.Log("Failed" + response.Error);
                }
            });
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("GUID"))
        {
            CreatePlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
