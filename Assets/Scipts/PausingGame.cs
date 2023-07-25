using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PausingGame : MonoBehaviour
{

    public GameObject PauseScreen;
    public InputAction InputAc;

    bool isPause = false;

    // Start is called before the first frame update
    void Awake()
    {
        InputAc.performed += ctx => { OnPause(); };
    }

    public void OnPause()
    {
        if (isPause == false)
        {
            Time.timeScale = 0;
            PauseScreen.SetActive(true);
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
            isPause = false;
        }
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.Debug.Log("Returning to main menu");
        SceneManager.LoadScene(0);
    }

    public void NextGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnEnable()
    {
        InputAc.Enable();
    }

    public void OnDisable()
    {
        InputAc.Disable();
    }
}
