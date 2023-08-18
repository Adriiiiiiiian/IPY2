/*
 * Author: Grace Foo
 * Date: 5/8/2023
 * Description: Code to control the dialog of the manager cat
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpeak : MonoBehaviour
{
    static int maxHP1 = 100;
    public int maxHP;
    public GameObject managerText;
    public GameObject failedToRepresent;
    public AudioSource dialog1;
    public AudioSource dialog2;
    public AudioSource dialog3;

    public AudioSource qn1;
    public AudioSource qn2;
    public AudioSource qn4;

    public AudioSource wrong;

    public AudioSource finalTalk;

    public int talking1 = 0;
    public static int talking = 0;

    bool TalkingToManager = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        talking1 = talking;
        maxHP = maxHP1;
    }

    public void showManagerUI()
    {
        managerText.gameObject.SetActive(true);
        talking = 1;
        TalkingToManager = true;

        dialog1.Play();

    }

    public void voice2()
    {
        dialog2.Play();
    }

    public void voice3()
    {
        dialog3.Play();
    }
    
    public void question1()
    {
        qn1.Play();
    }

    public void question2()
    {
        qn2.Play();
    }

    public void question4()
    {
        qn4.Play();
    }


    public void final()
    {
        finalTalk.Play();
    }
    

    public void wrongOption()
    {
        maxHP1 = maxHP1 - 20;
        //Debug.Log(maxHP);
        wrong.Play();
        if (maxHP1 == 0)
        {
            failedToRepresent.gameObject.SetActive(true);
            managerText.gameObject.SetActive(false);
        }
    }

    public void doneSpeaking()
    {
        
        managerText.gameObject.SetActive(false);
        talking = 0;
        TalkingToManager = false;

    }
}
