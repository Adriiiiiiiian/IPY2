/*
 * Author: Grace Foo
 * Date: 10/8/2023
 * Description: Code for the court UI
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class courtUI : MonoBehaviour
{
    public int maxHP = 100;
    public GameObject failedToRepresent;

    public GameObject courtMainUI;

    public AudioSource crossExamination;
    public AudioSource bgm1;

    /// <summary>
    /// cameras to switch around with
    /// </summary>
    public GameObject judge2rainCam;
    public GameObject player2RainCam;
    /// <summary>
    /// audio queues
    /// </summary>
    public AudioSource wipe;
    public AudioSource click;
    public AudioSource holditSound;
    public GameObject holdIt1;
    public GameObject previous1;

    /// <summary>
    /// UI and sound effects for the character buddy used for scene 4
    /// </summary>
    public GameObject buddyD1UI;
    public AudioSource buddy1;
    public AudioSource buddy2;
    public AudioSource buddy3;

    public AudioSource judge2;
    public AudioSource judge3;
    public GameObject penalizedUI;

    /// <summary>
    /// UI and sound effects for the character rain used for scene 4
    /// </summary>

    public AudioSource rain1;
    public AudioSource rainT1;
    public AudioSource rainT2;
    public AudioSource rainT3;
    public GameObject raintestUI;

    public AudioSource rain2;
    public AudioSource rain3;

    public GameObject offStatement1;
    public GameObject continuePlotUI;

    public GameObject thought1;
    public GameObject thought2;
    public GameObject thought3;
    public GameObject askGlovesUI;

    public GameObject rainResponseUI;

    /// <summary>
    /// ui to set inventory on or off
    /// </summary>
    public GameObject inventory1;

    bool witnessTestimonyShow = false;

    public void wipeSound()
    {
        wipe.Play();
    }

    public void clickSound()
    {
        click.Play();
    }

    public void HoldIt()
    {
        holditSound.Play();
        //holdIt1.gameObject.SetActive(false);
    }

    public void judgeDialog2()
    {
        judge2.Play();
    }

    public void judgeDialog3()
    {
        judge3.Play();
    }

    public void buddyDialog1()
    {
        buddyD1UI.gameObject.SetActive(true);
        buddy1.Play();
    }

    public void buddyDialog2()
    {
        buddy2.Play();
    }

    public void buddyDialog3()
    {
        buddy3.Play();
    }

    public void rainDialog1()
    {
        rain1.Play();
    }

    public void rainTestimony1()
    {
        rainT1.Play();
    }

    public void rainTestimony2()
    {
        rainT2.Play();
    }

    public void rainTestimony3()
    {
        rainT3.Play();
    }
    public void showRainTestimony()
    {
        bgm1.Stop();
        rainT1.Play();
        crossExamination.Play();
        raintestUI.gameObject.SetActive(true);
    }

    public void rainDialog2()
    {
        rain2.Play();
    }

    public void rainDialog3()
    {
        rain3.Play();
    }

    public void askingGloves()
    {
        //player2RainCam.gameObject.SetActive(true);
        askGlovesUI.gameObject.SetActive(true);
        //holditSound.Play();
        holdIt1.gameObject.SetActive(false);
        previous1.gameObject.SetActive(false);
    }
    public void rainResponse()
    {
        rainResponseUI.gameObject.SetActive(true);
    }
    /// <summary>
    /// when the witness is saying the truth for a statement, it is false
    /// </summary>
    public void witnessTestimonyRight()
    {
        witnessTestimonyShow = false;
    }
    /// <summary>
    /// when the witness is saying something wrong for a statement, it is true, so later down when the player provides the right evidence on this statement, the story continues
    /// </summary>
    public void witnessTestimonyWrong()
    {
        witnessTestimonyShow = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// if the player can poke the first hole in the story, with the right evidence, they can continue the story, but if shown on the wrong statement there is still penalty
    /// </summary>
    public void firstHole()
    {
        if (witnessTestimonyShow == true)
        {
            judge2rainCam.gameObject.SetActive(false);
            continuePlotUI.gameObject.SetActive(true);
            offStatement1.gameObject.SetActive(false);
            inventory1.gameObject.SetActive(false);
            rain2.Play();
            click.Play();
        }
        else
        {
            click.Play();
            wrongOption();
        }
    }

    public void secondHole()
    {

        //rainResponse1.gameObject.SetActive(true);
        //thought1.gameObject.SetActive(false);
        //rain2.Play();
        //click.Play();
    }
    public void wrongOption()
    {
        maxHP = maxHP - 5;
        penalizedUI.gameObject.SetActive(true);
        inventory1.gameObject.SetActive(false);
        click.Play();
        Debug.Log(maxHP);
        //wrong.Play();
        if (maxHP == 0)
        {
            //failedToRepresent.gameObject.SetActive(true);
            courtMainUI.gameObject.SetActive(false);
        }
    }

}


