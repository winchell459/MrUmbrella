using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCollide : MonoBehaviour
{
    bool isTrigger;
    public GameObject DialoguePanel;

    //public BoxCollider2D TheCollider;


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
        if(DialoguePanel == null)
        {
            DialoguePanel = GameObject.FindGameObjectWithTag("DialoguePanel");
        }

        if (isTrigger)
        {
            DialoguePanel.SetActive(true);
        }
        if (isTrigger == false)
        {
            DialoguePanel.SetActive(false);
        }

    }

}
