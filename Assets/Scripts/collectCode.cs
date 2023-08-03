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
    public collectUI updateText;
    public TextMeshProUGUI collectTextScene1;
    public AudioSource collectEffect;
    public GameObject lockDoor;

    /// <summary>
    /// the first list is all the the things needed to collect in the first scene
    /// the second list is all the things you need to collect in general in the game
    /// </summary>
    List<string> collectScene1 = new List<string> { "nail", "hammer", "screw", "screwdriver" };
    List<string> collectList = new List<string> { "nail", "hammer", "screw", "screwdriver", "crystal" };
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
        updateText.collectText(gameObject.name);

        //this destroys the game object clicked on and plays a sound effect
        Debug.Log("collected");
        Destroy(gameObject);
        //collectEffect.Play();
    }

}
