using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Some classes that will be loaded into thru JSON

//This will be the list of all the balls, for which the actual 
//BallBehavior script (attached to each ball prefab) willl use
[System.Serializable]
public class BallListObject
{
    public List<BallData> BallList;
}
//BallData stores the individual characteristics of each ball
[System.Serializable]
public class BallData
{
    public string color;
    public float velocity;
}

public class BallGenerator : MonoBehaviour
{
    public static BallListObject mBallList;
    float mTimer;
    float mMinStartTime = 2.0f;
    float mMaxStartTime = 5.0f;
    void Start()
    {
        //Load all the ball types into mBallList, which then can be accessed by the ball prefab
        string jsonString = File.ReadAllText(@"Assets/ballList.json");
        BallGenerator.mBallList = JsonUtility.FromJson<BallListObject>(jsonString);
        mTimer = Random.Range(mMinStartTime, mMaxStartTime);
    }

    void Update()
    {
        if (mTimer <= 0.0f)
        {
            SpawnBall();
            mTimer = Random.Range(mMinStartTime, mMaxStartTime);
        }
        mTimer -= Time.deltaTime;
    }
    
    void SpawnBall()
    {
        GameObject newBallPrefab = Resources.Load<GameObject>("Ball");
        Instantiate(newBallPrefab, transform.position, Quaternion.identity);
    }
}