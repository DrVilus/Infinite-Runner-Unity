using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPlatformMid : MonoBehaviour
{
    [SerializeField] private Transform Enemy1 = null;
    [SerializeField] private Transform dashPanel = null;
    [SerializeField] private Transform SpawnPoint1 = null;
    [SerializeField] private Transform SpawnPoint2 = null;

    [SerializeField] private Transform crystal = null;
    [SerializeField] private Transform CrystalSpawnPoint1 = null;
    [SerializeField] private Transform CrystalSpawnPoint2 = null;
    void Start()
    {
        var myBool = (Random.value < 0.5f);
        if(Random.value < 0.5f){
            if(Random.value < 0.5f){
                Instantiate(Enemy1,SpawnPoint1.position, Quaternion.identity);
            }else if((Random.value < 0.5f)){
                Instantiate(dashPanel,SpawnPoint1.position, Quaternion.identity);
            }
            if(Random.value < 0.5f){
                Instantiate(Enemy1,SpawnPoint2.position, Quaternion.identity);
            }else if((Random.value < 0.5f)){
                Instantiate(dashPanel,SpawnPoint2.position, Quaternion.identity);
            }
        }

        if(Random.value < 0.9f){
            Instantiate(crystal,CrystalSpawnPoint1.position, Quaternion.identity);
        }

        if(Random.value < 0.9f){
            Instantiate(crystal,CrystalSpawnPoint2.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = GlobalSettings.speed * Time.deltaTime;
        transform.Translate(Vector2.left*step);
        if (transform.position.x < -50){
            GlobalSettings.totalPlatformGenerated--;
            Destroy(gameObject);
        } 


    }
}
