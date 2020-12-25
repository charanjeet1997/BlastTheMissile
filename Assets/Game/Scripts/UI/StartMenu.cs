using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas joystickCanvas;
    public static StartMenu instance;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        Time.timeScale = 0;
    }
    public void OnStartGameClick()
    {
        joystickCanvas.enabled = true;
        mainMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void OnPlayerDestroy()
    {
        joystickCanvas.enabled = false;
        mainMenu.enabled = true;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
