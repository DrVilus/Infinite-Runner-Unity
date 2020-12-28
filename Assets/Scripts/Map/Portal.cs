using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
   // Start is called before the first frame update
    [SerializeField] private Transform dashPanel = null;
    [SerializeField] private Transform crystal = null;
    [SerializeField] private Transform SpawnPoint = null;
    [SerializeField] private Transform CrystalSpawnPoint = null;
    [SerializeField] private Transform portal = null;
    void Start()
    {
        if(Random.value < 0.5f){
            
        }else if(Random.value < 0.5f){
            Instantiate(dashPanel,SpawnPoint.position, Quaternion.identity);
        }

        if(Random.value < 0.9f){
            Instantiate(crystal,CrystalSpawnPoint.position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float step = GlobalSettings.speed * Time.deltaTime;
        transform.Translate(Vector2.left*step);
        if (transform.position.x < -100){
            GlobalSettings.totalPlatformGenerated--;
            Destroy(gameObject);
        } 


    }
}
