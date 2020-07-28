using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadManager : MonoBehaviour
{
    public bool isPlayerDied;

    public GameObject playerGO;


    void Update()
    {
        if (playerGO != null)
        {
            isPlayerDied = false;
        }
        else
        {
            isPlayerDied = true;
        }
        

        //playerGO = FindObjectOfType<GetPlayer>().Player;

        //Debug.Log("ture");

    }
    public void SetStatus(bool status)
    {
        if(playerGO != null)
        {
            playerGO.GetComponent<Health>().isPlayerDead = status;

        }
        
    }
    

}
