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

    [SerializeField] TextMeshProUGUI slideText;
    [SerializeField] TextMeshProUGUI score;

    float speedTimer = 0f;

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
        if(speedTimer>1f){
            speedTimer=0f;
            GlobalSettings.speed+=0.2f;
        }else{
            speedTimer+=0.002f;
        }
    }

    void updateUI(){
        healthText.text = "Health = " + GlobalSettings.currentHealth;
        healthSlider.value = (float)GlobalSettings.currentHealth/(float)GlobalSettings.maxHealth;

        staminaText.text = "Stamina = " + GlobalSettings.currentStamina;
        staminaSlider.value = GlobalSettings.currentStamina/GlobalSettings.maxStamina;

        slideText.text = "Slider " + GlobalSettings.slideEnabled;

        score.text = "Score = " + GlobalSettings.score;
    }

    void staminaReduce(){
        GlobalSettings.currentStamina -= 0.03f;
    }
}
