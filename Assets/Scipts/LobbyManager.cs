using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class LobbyManager : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void EnterDescription()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }

    public void LeaveGame()
    {
        UnityEngine.Application.Quit();
    }

}
