﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAltar : MonoBehaviour
{
    public GameObject player;

    public GameObject playerPrefab;

    public Health playerHealth;

    bool isRespawn;

    public GameObject Panel;
    public bool isSpawn;

    public bool isOnPanel;


    bool isSetPanel;

    private void Start()
    {
        Panel.SetActive(false);
    }
    private void Update()
    {
        Debug.Log(Panel.activeSelf);
        if(Panel.activeSelf == true)
        {
            isOnPanel = true;
        }
        else
        {
            isOnPanel = false;
        }

        if(FindObjectOfType<PlayerDeadManager>().isPlayerDied == true)
        {
            Debug.Log("YOMAMAA");
            playerHealth.RespawnPanel(Panel);

            


        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if(player != null) playerHealth = player.GetComponent<Health>();
            isRespawn = true;


        }
        else
        {

            
            FindObjectOfType<PlayerDeadManager>().SetStatus(false);
        }
        
    }
    public void Respawn(Transform respawnPos)
    {
        if (isSpawn == false)
        {
            GameObject Instance;
            Instance = Instantiate(playerPrefab, respawnPos.position, Quaternion.identity);
            FindObjectOfType<Follow>().SetTarget(Instance.transform);
            
            isSpawn = true;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRespawn == true)
        {
            if (collision.transform.CompareTag("Player"))
            {
                transform.GetChild(1).gameObject.SetActive(true);


                Panel.SetActive(false);
                isSpawn = false;

                Debug.Log("NOOOOO YOO MAAA");

                //FindObjectOfType<Health>().isSetPanel = false;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isRespawn == true)
        {
            if (collision.transform.CompareTag("Player"))
            {
                Panel.SetActive(false);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            transform.GetChild(1).gameObject.SetActive(false);
            isRespawn = false;

        }
    }

}
