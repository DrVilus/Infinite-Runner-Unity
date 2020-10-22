﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = GlobalSettings.speed*Time.deltaTime;
        transform.Translate(Vector2.left*step);
        if (transform.position.x < -20){
            Destroy(gameObject);
        } 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            GlobalSettings.score+=20;
            if(GlobalSettings.currentStamina<GlobalSettings.maxStamina-2){
                GlobalSettings.currentStamina+=2;
            }else{
                GlobalSettings.currentStamina=GlobalSettings.maxStamina;
            }
        }
    }
}
