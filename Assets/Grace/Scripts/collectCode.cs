/*
 * Author: Grace Foo
 * Date: 3/8/2023
 * Description: to destroy the item, and to play sound and to send over to collectListScript, on what to update the list on
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectCode : MonoBehaviour
{
    public TextMeshProUGUI collectText;
    //public collectListScript updateText;
    public TextMeshProUGUI collectTextScene1;
    public AudioSource collectEffect;
    public GameObject lockDoor;
    static int collectedObjects = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Collected()
    {
        //this sends the game object of the item collected over to collectListScript
        //updateText.collectText(gameObject.name);

        //this destroys the game object clicked on and plays a sound effect
        Debug.Log("collected");
        Destroy(gameObject);
        collectEffect.Play();
        collectedObjects = collectedObjects + 1;
        collectText.text = "evidence to collect left: " + (3- collectedObjects);
    }

}
