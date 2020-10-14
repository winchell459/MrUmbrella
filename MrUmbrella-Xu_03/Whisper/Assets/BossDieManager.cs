using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDieManager : MonoBehaviour
{
    public Health BH;
    public GameObject WinCanvas;
    
    void Update()
    {
        if(BH && BH.isBossDead)
        {
            Invoke("CallWinCanvas", 4.25f);
        }
    }
    public void CallWinCanvas()
    {
        WinCanvas.SetActive(true);
    }
    public void ExitAndBack()
    {
        WinCanvas.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
