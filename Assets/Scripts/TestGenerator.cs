using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerator : MonoBehaviour
{
    [SerializeField] private Transform Straight = null;
    [SerializeField] private Transform StraightPlatformEntrance = null;
    [SerializeField] private Transform StraightPlatformMid = null;
    [SerializeField] private Transform StraightPlatformEnd = null;
    [SerializeField] private Transform levelPartStart = null;
    private bool upPlatformStarted = false;
    Transform lastLevelPartTransform;


    // Start is called before the first frame update
    void Start()
    {
        lastLevelPartTransform = Spawn(Straight,levelPartStart.Find("EndPosition").position);
        // lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
        while(GlobalSettings.totalPlatformGenerated<GlobalSettings.maxPlatformGenerated){
            generatePlatforms();
            GlobalSettings.totalPlatformGenerated++;
        }

    }

    private Transform Spawn(Transform platform, Vector3 spawnPosition){
      Transform transform =  Instantiate(platform, spawnPosition, Quaternion.identity);
      return transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GlobalSettings.totalPlatformGenerated<GlobalSettings.maxPlatformGenerated){
            generatePlatforms();
            GlobalSettings.totalPlatformGenerated++;
        }

    }

    void generatePlatforms(){
        if(Random.value < 0.5f && upPlatformStarted==false){
                lastLevelPartTransform = Spawn(Straight,lastLevelPartTransform.Find("EndPosition").position);
            }else{
                if(upPlatformStarted==false){
                    lastLevelPartTransform = Spawn(StraightPlatformEntrance,lastLevelPartTransform.Find("EndPosition").position);
                    upPlatformStarted=true;
                }else{
                    if(Random.value < 0.5f){
                        lastLevelPartTransform = Spawn(StraightPlatformMid,lastLevelPartTransform.Find("EndPosition").position);
                    }else{
                        lastLevelPartTransform = Spawn(StraightPlatformEnd,lastLevelPartTransform.Find("EndPosition").position);
                        upPlatformStarted = false;
                    }
                }
                
            }
    }
}
