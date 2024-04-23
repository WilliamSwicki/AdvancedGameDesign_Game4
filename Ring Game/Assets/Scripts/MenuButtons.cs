using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject MenuScreen;
    public GameObject CreditsScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Debug.Log("Quiting...");
        Application.Quit();
    }
    public void Cedits()
    {
        if(MenuScreen.activeSelf)
        {
            CreditsScreen.SetActive(true);
            MenuScreen.SetActive(false);
        }
        else
        {
            MenuScreen.SetActive(true);
            CreditsScreen.SetActive(false);
        }
    }
    public void Close()
    {
        CreditsScreen.SetActive(false);
    }
}
