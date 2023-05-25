using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class TWOstaminaMaria : MonoBehaviour
{
    // stamina variables
    public Slider staminaBar;

    private float  maxStamina = 100;
    private float  currentStamina;
    
    public static TWOstaminaMaria  instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void UseStamina(int amount)
    {
       if (currentStamina - amount >= 0)
        {
            currentStamina -= amount * Time.deltaTime;
            staminaBar.value = currentStamina;
        }
        else
        {
            Debug.Log("Not enough stamina");
        }
    }

    public void RegenStamina()
    {
        if (currentStamina <= 100)
        {
            currentStamina += maxStamina / 100 * Time.deltaTime;
            staminaBar.value = currentStamina;
        }
    }
}
