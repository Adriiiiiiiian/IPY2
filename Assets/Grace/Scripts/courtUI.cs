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

    public GameObject buddyD1UI;
    public AudioSource buddy1;
    public AudioSource buddy2;
    public AudioSource buddy3;

    public AudioSource judge2;
    public AudioSource judge3;

    public AudioSource rain1;
    public GameObject raintestUI;

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

    public void showRainTestimony()
    {
        bgm1.Stop();
        crossExamination.Play();
        raintestUI.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void wrongOption()
    {
        maxHP = maxHP - 20;
        Debug.Log(maxHP);
        //wrong.Play();
        if (maxHP == 0)
        {
            //failedToRepresent.gameObject.SetActive(true);
            courtMainUI.gameObject.SetActive(false);
        }
    }

}
