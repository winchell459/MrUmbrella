using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnNoAltar : MonoBehaviour
{
    public GameObject Panel;

    // Update is called once per frame
    void LateUpdate()
    {
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == true)
        {
           
            Panel.SetActive(true);




        }
    }
    public void Respawn()
    {
        //Respawn(respawnPos.position);

        FindObjectOfType<PlayerHandler>().loadPlayerSaveRespawn();
    }
}
