﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject htp;
    public GameObject kickn;
    public GameObject crd;
    void Start()
    {
        GlobalSettings.currentHealth=GlobalSettings.maxHealth;
        GlobalSettings.currentStamina=GlobalSettings.maxStamina;
        GlobalSettings.score = 0;
         if(GlobalSettings.kickready==true){
       kickn.SetActive(true);
        }else   if(GlobalSettings.kickready==false){
       kickn.SetActive(false);
        }
    }
    public void stage1(){
        SceneManager.LoadScene(1);
    }
    public void rtnmainmenu(){
        SceneManager.LoadScene(0);
    }
    public void exitapp(){
        Application.Quit();
    }
      public void htpopenwindow()
    {
       htp.SetActive(true);
    }
    public void htpclosewindow()
    {
        htp.SetActive(false);
    }
       public void crdopenwindow()
    {
       crd.SetActive(true);
    }
    public void crdclosewindow()
    {
        crd.SetActive(false);
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
