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



    public void PlayGame()
    {

        transistion.SetTrigger("fadeTrigger");
        Debug.Log("nextScene");


    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }


    public void OnFadeComplete(int levelIndex)
    {
        SceneManager.LoadScene(1);
        Debug.Log("fade ends");
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
