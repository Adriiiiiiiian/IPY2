/*
 * Author: Grace Foo
 * Date: 5/8/2023
 * Description: Code to show and to controll the health bar
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthbar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    public float maxHP = 100f;
    ManagerSpeak Player;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<ManagerSpeak>();

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Player.maxHP;
        //Debug.Log("health" + currentHealth);

        Debug.Log(currentHealth);
        ///know how much percentage to fill the bar
        healthBar.fillAmount = currentHealth / maxHP;
       
    }
}
