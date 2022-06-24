using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Load game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    // Author button
    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");
    }
    // Load credit scene
    public void Exit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
