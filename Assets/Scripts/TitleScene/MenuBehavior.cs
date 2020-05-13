using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{

    public AnimationScript animScript;
    //get reference to button and animate it in

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName:"Sandbox");
    }

    public void DisplayCredits()
    {
        animScript.moveButtons = true;
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
