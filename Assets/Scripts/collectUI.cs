/*
 * Author: Grace Foo
 * Date: 3/8/2023
 * Description: Code to update the UI of things you want to collect
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectUI : MonoBehaviour
{
    public TextMeshProUGUI collectedUI;
    public TextMeshProUGUI doorText;
    public static GameObject doorUI;
    public GameObject doorMsg;
    /// <summary>
    /// the first list is all the things you need to collect in general in the game
    /// the second list is all the the things needed to collect in the first scene 
    /// </summary>
    public List<string> collectList = new List<string> { "nail", "hammer", "screw", "screwdriver", "crystal" };
    public List<string> collectScene1 = new List<string> { "nail", "hammer", "screw", "screwdriver" };
    // Start is called before the first frame update
    void Start()
    {
        doorUI = doorMsg;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void collectText(string update)
    {
        //to define the interger first
        int ind = 0;
        // to remove the game object out if the list
        foreach (string s in collectList)
        {
            if (s == update)
            {
                collectList.RemoveAt(ind);



                break;
            }
            ind++;
        }
        //to update the UI on what is left to collect
        collectedUI.text = "Items :\n";
        foreach (string s in collectList)
        {
            collectedUI.text += "\t" + s + "\n";
        }

        collectedUI.ForceMeshUpdate();
        //to reset the ind
        ind = 0;
        // to remove the game object out if the list
        foreach (string s in collectScene1)
        {
            if (s == update)
            {
                collectScene1.RemoveAt(ind);

                break;
            }
            ind++;
        }

        //to update the UI on what is left to collect for scene1
        doorText.text = "before entering you need to collect :\n";
        foreach (string s in collectScene1)
        {
            doorText.text += "\t" + s + "\n";
        }
    }

    public static void showDoorText()
    {
        //to show the message at the door
        doorUI.gameObject.SetActive(true);
    }
}
