/*
 * Author: Grace Foo
 * Date: 11/8/2023
 * Description: Code for transition
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIandAudio : MonoBehaviour
{

    public static AudioSource openDoor;
    public AudioSource doorCreek;

    public  GameObject door2UI;
    public static GameObject door2Text;

    public GameObject door3UI;
    public static GameObject door3Text;

    // Start is called before the first frame update
    void Start()
    {
        openDoor = doorCreek;
        door2Text = door2UI;
        door3Text = door3UI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void doorBGM()
    {
        openDoor.Play();
    }
    public static void showDoors2Text()
    {
        door2Text.gameObject.SetActive(true);
    }

    public static void showDoors3Text()
    {
        door3Text.gameObject.SetActive(true);
    }
}
