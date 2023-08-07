/*
 * Author: Grace Foo
 * Date: 7/8/2023
 * Description: Code for the ai of the maid
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class officeSpeak : MonoBehaviour
{
    public AudioSource bgm1;
    public AudioSource bgm2;

    public AudioSource ringing;
    public AudioSource newspaperNoise;

    public AudioSource dialog1;
    public AudioSource dialog2;
    public AudioSource dialog3;
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
        newspaperNoise.Play();
    }

    public void ringingNoise()
    {
        ringing.Play();
    }
    public void voice1()
    {
        bgm1.Pause();
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


}
