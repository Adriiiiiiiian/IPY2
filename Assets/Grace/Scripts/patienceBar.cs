/*
 * Author: Grace Foo
 * Date: 11/8/2023
 * Description: Code for the patience bar for the parrot ai scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class patienceBar : MonoBehaviour
{
    private Image healthBar;

    public float currentHealth;
    public float maxHP = 100f;
    PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Player.maxHP;
      

        ///know how much percentage to fill the bar
        
        healthBar.fillAmount = currentHealth / maxHP;

    }
}
