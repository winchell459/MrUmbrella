using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    //public bool isLastSentece;

    //public string LevelName;

    //public bool isLevelChange;

    
    public List<GameObject> DialogueTriggerPoint;

    public int whichIsTriggered;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        Debug.Log(sentences);
    }

    public void StartDialogue(Dialogue dialogue)
    {


        nameText.text = dialogue.name;

        sentences.Clear();
        //Debug.Log(sentences);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            //Debug.Log(sentences);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Debug.Log("IT worked");
        if (sentences.Count == 0)
        {

            //Debug.Log(sentences);
            EndDialogue();

            

            //Debug.Log("Ok");
            return;
        }
        DialogueTriggerPoint[whichIsTriggered].GetComponent<BoxCollider2D>().enabled = true;



        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        //Debug.Log(sentence);
    }

    void EndDialogue()
    {
        DialogueTriggerPoint[whichIsTriggered].GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("TESTING");

    }

}
