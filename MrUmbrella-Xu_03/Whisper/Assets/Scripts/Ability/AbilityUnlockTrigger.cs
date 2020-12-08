using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUnlockTrigger : MonoBehaviour
{
    public AbilityObject ao;
    public GameObject theCanvas;
    public AudioClip CongratsClip;

    private void Start()
    {
        theCanvas.SetActive(false);
        if (PlayerHandler.PH.AbilityUnlocked(ao)) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHandler>().AbilityUnlock(ao);
            gameObject.SetActive(false);

            theCanvas.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = ao.Detail + "!";

            theCanvas.SetActive(true);
            theCanvas.GetComponent<AudioSource>().clip = CongratsClip;
            theCanvas.GetComponent<AudioSource>().Play();

            Time.timeScale = 0;
        }
        
    }

    public void Exit()
    {
        theCanvas.SetActive(false);
        Debug.Log("p");
        Time.timeScale = 1;
    }
}
