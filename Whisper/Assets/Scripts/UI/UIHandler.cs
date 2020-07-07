using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject AbilityUIPrefab;
    public GameObject AbPanel;
    public bool OnHold;

    // Start is called before the first frame update
    void Start()
    {
        loadAbilityPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadAbilityPanel()
    {
        AbPanel = Instantiate(AbilityUIPrefab, Vector3.zero, Quaternion.identity);
    }
}
