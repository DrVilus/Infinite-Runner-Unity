using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


//Control stats like healths and stuff, variable located in global settings since i'm lazy asf
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Slider healthSlider;

    [SerializeField] TextMeshProUGUI staminaText;
    [SerializeField] Slider staminaSlider;

    void Start()
    {
        int currentHealth = GlobalSettings.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
        
    }

    void FixedUpdate()
    {
        staminaReduce();
    }

    void updateUI(){
        healthText.text = "Health = " + GlobalSettings.currentHealth;
        healthSlider.value = (float)GlobalSettings.currentHealth/(float)GlobalSettings.maxHealth;

        staminaText.text = "Stamina = " + GlobalSettings.currentStamina;
        staminaSlider.value = GlobalSettings.currentStamina/GlobalSettings.maxStamina;
    }

    void staminaReduce(){
        GlobalSettings.currentStamina -= 0.03f;
    }
}
