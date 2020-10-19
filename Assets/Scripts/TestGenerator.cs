using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGenerator : MonoBehaviour
{
    [SerializeField] private Transform Straight = null;
    [SerializeField] private Transform levelPartStart = null;
    Transform lastLevelPartTransform;
    // Start is called before the first frame update

    static public int totalPlatform=0;
    void Start()
    {
        
        lastLevelPartTransform = Spawn(levelPartStart.Find("EndPosition").position);
        // lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
        // lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
        // lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
    }

    private Transform Spawn(Vector3 spawnPosition){
      Transform transform =  Instantiate(Straight, spawnPosition, Quaternion.identity);
      return transform;
    }

    // Update is called once per frame
    void Update()
    {
        while(totalPlatform<5){
            lastLevelPartTransform = Spawn(lastLevelPartTransform.Find("EndPosition").position);
            totalPlatform++;
        }
    }
}
