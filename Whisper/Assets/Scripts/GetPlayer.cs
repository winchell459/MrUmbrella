using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{

    public GameObject Player;

    bool isGetOnce;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject;

        FindObjectOfType<PlayerDeadManager>().playerGO = Player;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player == null && isGetOnce == false)
        {
            

            Debug.Log("YES");

            isGetOnce = true;
        }
        
    }
}
