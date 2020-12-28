using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyGroundBase : MonoBehaviour
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
        if (transform.position.x < -50){
            GlobalSettings.totalPlatformGenerated--;
            Destroy(gameObject);
        } 
    }
}
