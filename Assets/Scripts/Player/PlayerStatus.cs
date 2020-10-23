using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    int speedTimerScoreCheck=0;

    void Start()
    {
        int currentHealth = GlobalSettings.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
         
 if(GlobalSettings.currentHealth==0){
        GlobalSettings.currentHealth=GlobalSettings.maxHealth;
                GlobalSettings.currentStamina=GlobalSettings.maxStamina;

        SceneManager.LoadScene(2);
    }else if(GlobalSettings.currentStamina==0){
                GlobalSettings.currentHealth=GlobalSettings.maxHealth;
        GlobalSettings.currentStamina=GlobalSettings.maxStamina;
        SceneManager.LoadScene(2);
}
    
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
        if(speedTimerScoreCheck==10){
            GlobalSettings.score+=1;
            if(GlobalSettings.slideEnabled==true){
                GlobalSettings.score+=1;
            }
            speedTimerScoreCheck=0;
        }else{
            speedTimerScoreCheck+=1;
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
