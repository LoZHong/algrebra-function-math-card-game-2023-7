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
    }

    public void LeaveGame()
    {
        UnityEngine.Application.Quit();
    }

}
