/*
 * Author: Grace Foo
 * Date: 6/8/2023
 * Description: Code for the speech of the maid
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidCatSpeak : MonoBehaviour
{
    public GameObject maidText;
    public GameObject questtext1;
    public GameObject questtext2;

    public AudioSource dialog1;
    public AudioSource dialog2;
    public AudioSource dialog3;

    public int talking = 0;

    public void showMaidUI()
    {
        maidText.gameObject.SetActive(true);

        dialog1.Play();
        talking = 1;

    }

    public void voice2()
    {
        dialog2.Play();
    }

    public void voice3()
    {
        dialog3.Play();
    }

    public void doneSpeaking()
    {

        maidText.gameObject.SetActive(false);
        talking = 0;
        questtext1.gameObject.SetActive(false);
        questtext2.gameObject.SetActive(true);

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
