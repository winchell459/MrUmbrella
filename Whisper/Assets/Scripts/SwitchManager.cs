using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public bool isSwitch;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("IS WORKING");

            if (isSwitch == false)
            {
                Player.transform.GetChild(1).gameObject.SetActive(true);
                FindObjectOfType<WeaponFollow>().UnShowSwitchWeapon();
            }
            else
            {
                FindObjectOfType<WeaponFollow>().ShowSwitchWeapon();
                Player.transform.GetChild(1).gameObject.SetActive(false);

            }
        }
        
        if (Input.GetKeyUp(KeyCode.F))
        {
            isSwitch = !isSwitch;
        }
        
    }
}
