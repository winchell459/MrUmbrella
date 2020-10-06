using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollide : MonoBehaviour
{
    bool isTrigger;
    private GameObject DialoguePanel;
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
            //Debug.Log("test");


        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.CompareTag("NPC") && isTrigger)
        {
            isTrigger = false;


        }
    }
    bool ignoreDialoguePanel = false;
    private void Update()
    {
        if (!ignoreDialoguePanel)
        {
            

            

        }

        if (!DialoguePanel)
        {
            if (FindObjectOfType<DialogueManager>())
            {

                DialoguePanel = FindObjectOfType<DialogueManager>().GetDialoguePanel();
            }

        }
        else
        {
            //ignoreDialoguePanel = true;
            if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false)
            {

                if (isTrigger)
                {
                    DialoguePanel.SetActive(true);
                    Debug.Log("test");
                }
                else
                {
                    DialoguePanel.SetActive(false);
                    Debug.Log("testOh");

                }




            }


        }
    }

}
