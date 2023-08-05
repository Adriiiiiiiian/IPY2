/*
 * Author: Grace Foo
 * Date: 4/8/2023
 * Description: Code for the stamina bar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    /// <summary>
    /// main stamina parameter
    /// </summary>
    //public float playerStamina = 100.0f;
    //[SerializeField] private float maxStamina = 100.0f;
    //[HideInInspector] public bool hasRegenerated = true;
    //[HideInInspector] public bool weAreSprinting = true;


    [Range(0, 50)] [SerializeField] private float staminaDrain = 1.0f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 3.0f;

    //[SerializedField] private int fastSpeed = 2f;

    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;

    private PlayerController playerController;




    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateStamina(0);
        ///regenerates their stamina
        if (!playerController.weAreSprinting)
        {

            if (playerController.playerStamina <= playerController.maxStamina - 0.01)
            {
                playerController.playerStamina += staminaRegen; //* Time.deltaTime;
                Debug.Log("recover");
                if (playerController.playerStamina >= playerController.maxStamina)
                {
                    //Debug.Log("sprint pool test 1");
                    playerController.hasRegenerated = true;
                    sliderCanvasGroup.alpha = 0;
                    //UpdateStamina(0);
                }
            }
        }
    }

    public void sprinting()
    {
        if (playerController.hasRegenerated)
        {
            ///this is to check if you have regenerated and to drain your stamina and show your stamina pool

            playerController.weAreSprinting = true;
            playerController.playerStamina -= staminaDrain; //* Time.deltaTime;
            Debug.Log(playerController.playerStamina);
            UpdateStamina(1);
            if (playerController.playerStamina <= 0)
            {
                ///once done sprinting it hides the stamina pool

                playerController.hasRegenerated = false;
                sliderCanvasGroup.alpha = 0;
            }
        }
    }

    void UpdateStamina(int value)
    {
        ///if value is equal to zero, then the stamina pool wont show
        staminaProgressUI.fillAmount = playerController.playerStamina / playerController.maxStamina;
        if (value == 0)
        {

            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            ///if the value is equal to one, the stamina pool will show
            sliderCanvasGroup.alpha = 1;
        }
    }
}