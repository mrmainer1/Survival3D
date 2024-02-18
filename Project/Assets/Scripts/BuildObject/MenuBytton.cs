using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBytton : MonoBehaviour
{
    public string action;
    public bool isGame;

    private void Update()
    {
        if (isGame)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                LevelStart();
            }
        }
    }

    private void OnMouseDown()
    {
        if(action == "Start")
        {
            LevelStart();
        }

        if(action == "Quit")
        {
            Quit();
        }
    }
    public void LevelStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
