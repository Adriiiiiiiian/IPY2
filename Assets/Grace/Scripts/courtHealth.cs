/*
 * Author: Grace Foo
 * Date: 11/8/2023
 * Description: Code for the court scene healthBar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class courtHealth : MonoBehaviour
{
    private Image healthBar;

    public float currentHealth;
    public float maxHP = 100f;
    courtUI Player;
 
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<courtUI>();

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Player.maxHP;
      


        ///know how much percentage to fill the bar

        healthBar.fillAmount = currentHealth / maxHP;

    }
}
