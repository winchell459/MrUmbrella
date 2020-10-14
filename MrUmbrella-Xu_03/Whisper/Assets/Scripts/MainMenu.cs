using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public UnityEngine.UI.Button ContinueButton;
    public string FirstSceneName = "1_00";
    bool isOn;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SavedGame"))
        {
            ContinueButton.interactable = false;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetFloat("SavedGame", System.DateTime.Now.Second);
        PlayerHandler.ResetSave = true;
        startGame();
        //MusicBackgroundHandler.StaticMBH.OnSceneEnd();
    }
    public void Continue()
    {
        startGame();
    }
    private void startGame()
    {
        //MusicBackgroundHandler.StaticMBH.OnSceneStt();
        UnityEngine.SceneManagement.SceneManager.LoadScene(FirstSceneName);
    }

    public void toggleCredits(GameObject creditsPanel)
    {

        isOn = !isOn;
        Debug.Log(isOn);
        if (isOn)
        {
            creditsPanel.SetActive(true);
        }
        else
        {
            creditsPanel.SetActive(false);
            Debug.Log("settofalse");
        }
       
        




    }
}
