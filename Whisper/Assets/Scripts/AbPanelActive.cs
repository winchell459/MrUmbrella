using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbPanelActive : MonoBehaviour
{
    public GameObject AbilityUIPrefab;
    public GameObject AbPanel;
    public bool OnHold;

    private void Start()
    {
        loadAbilityPanel();
        
        AbPanel.SetActive(false);
    }

    public void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnHold = !OnHold;
            FindObjectOfType<PlayerHandler>().SavePlayerPrefs();
        }

        if(OnHold == true)
        {
            AbPanel.SetActive(true);
            AbPanel.transform.GetChild(0).GetComponent<AbilityUI>().DisplayAbilities();
            
        }
        else
        {
            AbPanel.SetActive(false);

            //FindObjectOfType<PlayerHandler>().SavePlayerPrefs();
        }
    }
    private void loadAbilityPanel()
    {
        AbPanel = Instantiate(AbilityUIPrefab, Vector3.zero, Quaternion.identity);
    }
    private void Update()
    {
        Debug.Log(gameObject);
    }
}
