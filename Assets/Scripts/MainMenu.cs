using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void progressMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void BackToStart()
    {
        SceneManager.LoadScene(0);
    }

    public void jigSawPuzz()
    {
        SceneManager.LoadScene(3);
    }

    public void simonGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Matchingcards()
    {
        SceneManager.LoadScene(5);
    }

    public void BackToGameMenu()
    {
        SceneManager.LoadScene(1);
    }
}
