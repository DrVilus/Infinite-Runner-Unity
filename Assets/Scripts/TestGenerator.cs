using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerator : MonoBehaviour
{
    [SerializeField] private Transform Straight = null;
    [SerializeField] private Transform StraightPlatformEntrance = null;
    [SerializeField] private Transform levelPartStart = null;
    private bool upPlatformStarted = false;
    Transform lastLevelPartTransform;
    // Start is called before the first frame update

    static public int totalPlatform=0;
    void Start()
    {
        
        lastLevelPartTransform = Spawn(Straight,levelPartStart.Find("EndPosition").position);
        // lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
        // lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
        // lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
    }

    private Transform Spawn(Transform platform, Vector3 spawnPosition){
      Transform transform =  Instantiate(platform, spawnPosition, Quaternion.identity);
      return transform;
    }

    // Update is called once per frame
    void Update()
    {
        while(totalPlatform<5){
            if(Random.value < 0.5f ){
                lastLevelPartTransform = Spawn(Straight,lastLevelPartTransform.Find("EndPosition").position);
            }else{
                lastLevelPartTransform = Spawn(StraightPlatformEntrance,lastLevelPartTransform.Find("EndPosition").position);
            }
            
            totalPlatform++;
        }
    }
}
