using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For Straight
public class StraightGround : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Enemy1 = null;
    [SerializeField] private Transform dashPanel = null;
    [SerializeField] private Transform SpawnPoint = null;
    void Start()
    {
        if(Random.value < 0.5f){
            Instantiate(Enemy1,SpawnPoint.position, Quaternion.identity);
        }else if((Random.value < 0.5f)){
            Instantiate(dashPanel,SpawnPoint.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = GlobalSettings.speed * Time.deltaTime;
        transform.Translate(Vector2.left*step);
        if (transform.position.x < -50){
            GlobalSettings.totalPlatformGenerated--;
            Destroy(gameObject);
        } 


    }
}   
