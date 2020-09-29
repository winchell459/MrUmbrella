using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    bool isClick;
    public Text settingText;

    public GameObject thePanel;

    public void togglePanel(GameObject Panel)
    {
        
        Panel.SetActive(!Panel.activeInHierarchy);

        isClick = !isClick;

        if (isClick)
        {
            settingText.text = "X";
        }
        else
        {
            settingText.text = "Settings";
        }

    }
    public void KTR()
    {
        if(!FindObjectOfType<PlayerDeadManager>().isPlayerDied) FindObjectOfType<PlayerDeadManager>().playerGO.gameObject.GetComponent<Health>().TakeDamage(FindObjectOfType<PlayerDeadManager>().playerGO.gameObject.GetComponent<Health>().maxHealth);
    }

    private void Update()
    {
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied)
        {
            //settingText.gameObject.transform.parent.gameObject.SetActive(false);
            thePanel.SetActive(false);
        }
    }
}
