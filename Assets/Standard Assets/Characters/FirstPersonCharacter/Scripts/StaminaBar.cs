using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    public float currentStaminaPoints;
    public float maxStaminaPoints = 100f;
    private float staminaBurnRate;
    public float staminaBurnMult;
    private float staminaRegenRate;
    public float staminaRegenMult;

    private RigidbodyFirstPersonController charController;

    private void Start()
    {
        currentStaminaPoints = maxStaminaPoints;
        staminaBar.maxValue = maxStaminaPoints;
        staminaBar.value = maxStaminaPoints;

        staminaBurnRate = 2;
        staminaRegenRate = 2;

        charController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (charController.Velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            staminaBar.value -= Time.deltaTime / staminaBurnRate * staminaBurnMult;
        }
        else
        {
            staminaBar.value += Time.deltaTime / staminaRegenRate * staminaRegenMult;
        }

        if(staminaBar.value >= maxStaminaPoints)
        {
            staminaBar.value = maxStaminaPoints;
        }
        else if(staminaBar.value <= 0)
        {
            staminaBar.value = 0;
            charController.movementSettings.RunMultiplier=1f;
        }
        else if(staminaBar.value >= 0)
        {
            charController.movementSettings.RunMultiplier = 2f;
        }
    }

    public void setMaxStamina(float ammount)
    {
        staminaBar.maxValue = ammount;
        staminaBar.value = ammount;
    }

    public void setStamina(float ammount)
    {
        staminaBar.value = ammount;
    }

    
}
