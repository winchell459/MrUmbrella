using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public UnityEngine.UI.Button ContinueButton;
    public string FirstSceneName = "1_00";
    
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
    }
    public void Continue()
    {
        startGame();
    }
    private void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(FirstSceneName);
    }
}
