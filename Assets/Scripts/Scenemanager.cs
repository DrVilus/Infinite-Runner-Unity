using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalSettings.currentHealth=GlobalSettings.maxHealth;
        GlobalSettings.currentStamina=GlobalSettings.maxStamina;
        GlobalSettings.score = 0;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
