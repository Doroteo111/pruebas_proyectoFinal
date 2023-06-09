using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStaminaBar : MonoBehaviour
{
  

    //VARIABLES
    public Slider staminaSlider;

    public float maxStamina = 100f;
   
    private float currentStamina;   //actual stamina (important)
    private float regenerateStaminaTime = 0.1f;
    private float regenerateAmount = 2;
    private float losingStaminaTime = 0.1f;

    //coroutine reference
    private Coroutine myCoroutineLosing;
    private Coroutine myCoroutineRegenerate;

    void Start()
    {
        //when start the game --> bar complete
        currentStamina = maxStamina;         
        staminaSlider.maxValue = maxStamina;

        staminaSlider.value = maxStamina;
    }

    public void UseStamina(float amount) //when we run
    {
        if (currentStamina-amount > 0)
        {
            if(myCoroutineLosing != null)
            {
                StopCoroutine(myCoroutineLosing);
            }

            myCoroutineLosing = StartCoroutine(LosingStaminaCorutine(amount));

            if (myCoroutineRegenerate != null)
            {
                StopCoroutine(myCoroutineRegenerate);
            }
            myCoroutineRegenerate = StartCoroutine(RegenerateStaminaCorutine());
        }
        else
        {
            Debug.Log("no Stamina");
            FindObjectOfType<MovmentScene2>().hasStamina = false;
        }


    }
        
    private IEnumerator LosingStaminaCorutine(float amount)
    {
        while (currentStamina >= 0)
        {
            currentStamina -= amount; //losing stamina

            staminaSlider.value = currentStamina; //reload stamina bar

            yield return new WaitForSeconds(losingStaminaTime);
        }
        myCoroutineLosing = null;
        FindObjectOfType<MovmentScene2>().hasStamina = false;
       
       
    }

    private IEnumerator RegenerateStaminaCorutine()
    {
        yield return new WaitForSeconds(1);
        while (currentStamina < maxStamina)
        {
            currentStamina += regenerateAmount; //win stamina

            staminaSlider.value = currentStamina; //reload stamina bar

            yield return new WaitForSeconds(regenerateStaminaTime);
        }
        myCoroutineRegenerate = null;
    }
}
