using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
public class LeaderBoardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
         {
             if (response.success)
             {
                 Debug.Log("Sucess");
             }
             else
             {
                 Debug.Log("Failed");
             }
         }
        );
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
           {
               if (response.success)
               {
                   Debug.Log("Sucess");
               }
               else
               {
                   Debug.Log("Failed");
               }
           }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
