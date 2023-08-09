/*
 * Author: Grace Foo
 * Date: 4/8/2023
 * Description: Code for the music slider
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class musicslider : MonoBehaviour
{
    [SerializeField] private AudioMixer mymixer;
    [SerializeField] private Slider musicAdjust;

    public void SetAudioMusic()
    {
        float volume = musicAdjust.value;
        mymixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetAudioMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
