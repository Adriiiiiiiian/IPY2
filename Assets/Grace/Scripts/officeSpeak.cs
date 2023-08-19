/*
 * Author: Grace Foo
 * Date: 7/8/2023
 * Description: Code for the UI for the first office scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeSpeak : MonoBehaviour
{
    /// <summary>
    /// BGM
    /// </summary>
    public AudioSource bgm1;
    public AudioSource bgm2;
    /// <summary>
    /// sound effects
    /// </summary>
    public AudioSource ringing;
    public AudioSource newspaperNoise;
    /// <summary>
    /// dialog sounds
    /// </summary>
    public AudioSource dialog1;
    public AudioSource dialog2;
    public AudioSource dialog3;

    public GameObject playerCam;
    public GameObject zoomingIn;

    public Animator phone;
    // note to self the voice is between d and s

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newspaper()
    {
        //StartCoroutine(sequence());
        newspaperNoise.Play();
    }
    IEnumerator sequence()
    {
        yield return new WaitForSeconds(5);
        zoomingIn.SetActive(false);
        playerCam.SetActive(true);
    }
    public void ringingNoise()
    {
        ringing.Play();
        phone.SetTrigger("startring");
    }
    public void voice1()
    {
        bgm1.Pause();
        dialog1.Play();
        bgm2.Play();
        ringing.Pause();
        phone.SetTrigger("endring");
    }

    public void voice2()
    {

        dialog2.Play();
    }

    public void voice3()
    {
        dialog3.Play();
    }


}
