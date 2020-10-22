using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    //Important "script" that stores global value for the lazy

    static public float speed = 10f; //Handles the speed where everything move left exceot the player

    static public int maxHealth = 100; // Self Explanatory, it's player max health
    static public int currentHealth = 100;// always set the same as max health before play

    static public float maxStamina = 100;
    static public float currentStamina = 100;

    static public bool slideEnabled=false;
    
    static public int score = 0;
    
    static public int maxPlatformGenerated = 5;//the maximum platform that will be generated

    static public int totalPlatformGenerated = 0;//no touch, stays at 0, idk what else to do lol

    
}
