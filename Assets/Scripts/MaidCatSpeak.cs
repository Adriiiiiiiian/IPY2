using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidCatSpeak : MonoBehaviour
{
    public GameObject maidText;
   
    public AudioSource dialog1;
    public AudioSource dialog2;
    public AudioSource dialog3;

    public void showMaidUI()
    {
        maidText.gameObject.SetActive(true);

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

    public void doneSpeaking()
    {

        maidText.gameObject.SetActive(false);

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
