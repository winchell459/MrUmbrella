using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Button btn;

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
    private void Update()
    {
        if(dialogueText == null)
        {
            dialogueText = GameObject.FindGameObjectWithTag("DialoguePanel").transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
            Debug.Log("r");
            
        }
        if (nameText == null)
        {
            nameText = GameObject.FindGameObjectWithTag("DialoguePanel").transform.GetChild(1).gameObject.GetComponent<Text>();
        }
        if(btn == null)
        {
            btn = GameObject.FindGameObjectWithTag("DialoguePanel").transform.GetChild(2).gameObject.GetComponent<Button>();
            btn.onClick.AddListener(DisplayNextSentence);
        }
        
        

    }

}
