using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        foreach(GameObject npc in FindObjectOfType<DialogueManager>().DialogueTriggerPoint)
        {
            if(npc == gameObject)
            {
                FindObjectOfType<DialogueManager>().whichIsTriggered = FindObjectOfType<DialogueManager>().DialogueTriggerPoint.IndexOf(npc);
            }
        }

        
    }
}
