using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPlatformEnd : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform Enemy1 = null;
    [SerializeField] private Transform SpawnPoint = null;
    void Start()
    {
        var myBool = (Random.value < 0.5f);
        if(myBool==true){
            Instantiate(Enemy1,SpawnPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = GlobalSettings.speed * Time.deltaTime;
        transform.Translate(Vector2.left*step);
        if (transform.position.x < -50){
            Destroy(gameObject);
            TestGenerator.totalPlatform-=1;
        } 


    }
}
