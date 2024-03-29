﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyScript : MonoBehaviour
{
    [SerializeField] int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = GlobalSettings.speed*Time.deltaTime;
        transform.Translate(Vector2.left * step * 1.5f);
        if (transform.position.x < -20){
            Destroy(gameObject);
        } 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player got hit");
            Destroy(this.gameObject);
            if(GlobalSettings.kicked==true){
                GlobalSettings.slideEnabled=false;
                GlobalSettings.score+=30;
                
                GlobalSettings.speed-=GlobalSettings.panelSpeedBoost;
            }else{
                GlobalSettings.score-=50;
                if(GlobalSettings.score<0){
                    GlobalSettings.score=0;
                }
                GlobalSettings.currentHealth-=damage;
            }
        }

       
    }
}
