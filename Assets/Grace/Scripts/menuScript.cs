/*
 * Author: Grace Foo
 * Date: 3/8/2023
 * Description: code for the main menu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public Animator transistion;

    public GameObject menu;

    public void PlayGame()
    {
        nextSceneAnimation.FadeToLevel1();
        transistion.SetTrigger("fadeTrigger");
        Debug.Log("nextScene");


    }
    public void QuitGame()
    {
        Debug.Log("quit");
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
