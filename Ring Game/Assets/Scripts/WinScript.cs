using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public int winScreen;
    public void WinScene()
    {
        SceneManager.LoadScene(winScreen);
    }
}
