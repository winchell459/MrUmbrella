using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollide : MonoBehaviour
{
    bool isTrigger;
    public GameObject DialoguePanel;
    GameObject Instance;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("NPC") && !isTrigger)
        {
            isTrigger = true;
            col.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            


        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("NPC") && isTrigger)
        {
            isTrigger = false;


        }
    }

    private void Update()
    {
        if(FindObjectOfType<PlayerDeadManager>().isPlayerDied == false)
        {
            
            if(isTrigger == true  && Instance == null)
            {
                Instance = Instantiate(DialoguePanel, Vector3.zero, Quaternion.identity);
            }
            else if(isTrigger == false && Instance)
            {
                Destroy(Instance);
            }
            

           
            
        }
        
        

    }

}
