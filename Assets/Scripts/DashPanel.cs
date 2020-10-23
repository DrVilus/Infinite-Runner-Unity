﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPanel : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player got hit");
            Destroy(this.gameObject);
            GlobalSettings.currentStamina = GlobalSettings.maxStamina;
            if(GlobalSettings.slideEnabled == false){
                GlobalSettings.speed+=GlobalSettings.panelSpeedBoost;
            }
            GlobalSettings.slideEnabled = true;
            GlobalSettings.score+=50;
        }
    }
}