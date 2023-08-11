/*
 * Author: Grace Foo
 * Date: 9/8/2023
 * Description: Code for showing the game over screen
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class showGameOver : MonoBehaviour
{
    public static GameObject gameoverUI;
    public GameObject OverUI;
    public static AudioSource overSound;
    public AudioSource gameoverSound;
    int currentScene;
    //private GameObject deathUI;
    private static nextSceneAnimation transition;
    private nextSceneAnimation Fade;

    void Start()
    {
        gameoverUI = OverUI;
        overSound = gameoverSound;
        transition = Fade;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        
    }

    public void gameOverPopup()
    {
        gameoverUI.gameObject.SetActive(true);
        overSound.Play();
        
    }

    public static void MainMenu()
    {
        if (gameoverUI != null)
        {
            transition = gameoverUI.GetComponent<nextSceneAnimation>();
            nextSceneAnimation.FadeToMenu();
            Debug.Log("mainMenuLoad");
        }

    }
    public void testfunction()
    {
        Debug.Log("testing");
    }
    public void restart()
    {
        Debug.Log(currentScene);
        Debug.Log("restart");
        if (currentScene == 1)
        {
            Debug.Log("restart1");
            //GetComponent<nextSceneAnimation>().FadeToLevel1();
            if (gameoverUI != null)
            {
                
                transition = gameoverUI.GetComponent<nextSceneAnimation>();
                nextSceneAnimation.FadeToLevel1();
            }
        }
        if (currentScene == 2)
        {
            Debug.Log("restart1");
            //GetComponent<nextSceneAnimation>().FadeToLevel1();
            if (gameoverUI != null)
            {
                Debug.Log("fade back to spaceship");
                transition = gameoverUI.GetComponent<nextSceneAnimation>();
                nextSceneAnimation.FadeToLevel2();
            }
        }
        if (currentScene == 3)
        {
            Debug.Log("restart1");
            //GetComponent<nextSceneAnimation>().FadeToLevel1();
            if (gameoverUI != null)
            {
                Debug.Log("fade back to spaceship");
                transition = gameoverUI.GetComponent<nextSceneAnimation>();
                nextSceneAnimation.FadeToLevel3();
            }
        }
    }
}
