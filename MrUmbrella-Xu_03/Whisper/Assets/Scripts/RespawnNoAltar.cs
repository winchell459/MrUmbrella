using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnNoAltar : MonoBehaviour
{
    public GameObject Panel;
    public AudioClip death;
    public AudioSource RAS;

    // Update is called once per frame

    private void Start()
    {
        RAS = GetComponent<AudioSource>();
    }
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
