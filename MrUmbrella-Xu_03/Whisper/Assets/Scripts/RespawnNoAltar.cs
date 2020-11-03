using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnNoAltar : MonoBehaviour
{
    public GameObject Panel;
    public AudioClip death;
    public AudioSource RAS;
    public GameObject player;

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
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            FindObjectOfType<PlayerDeadManager>().SetStatus(false);
        }
    }
    public void Respawn()
    {
        //Respawn(respawnPos.position);

        FindObjectOfType<PlayerHandler>().loadPlayerSaveRespawn();
    }
}
