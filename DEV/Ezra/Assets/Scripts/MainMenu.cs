using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void MenuPlay()  // go to AR camera
    {
        SceneManager.LoadScene(1);
    }

    public void MenuCollection()    // go to collection page
    {
        SceneManager.LoadScene(2);
    }

    public void MenuQuit()  // quit the app
    {
        Application.Quit();
    }
}
