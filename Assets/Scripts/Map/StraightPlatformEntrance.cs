using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPlatformEntrance : MonoBehaviour
{
    [SerializeField] private Transform Enemy1 = null;
    [SerializeField] private Transform SpawnPoint1 = null;
    [SerializeField] private Transform SpawnPoint2 = null;
    [SerializeField] private Transform crystal = null;
    [SerializeField] private Transform CrystalSpawnPoint = null;
    void Start()
    {
        if(Random.value < 0.5f){
            if(Random.value < 0.5f){
                Instantiate(Enemy1,SpawnPoint1.position, Quaternion.identity);
            }
            if(Random.value < 0.5f){
                Instantiate(Enemy1,SpawnPoint2.position, Quaternion.identity);
            }
        }

        if(Random.value < 0.9f){
            Instantiate(crystal,CrystalSpawnPoint.position, Quaternion.identity);
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
