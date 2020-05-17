using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float mSpeed = 15.0f;
    public float mRunSpeed = 25.0f;
    float mStartRunTime = 1.0f;
    float mRunTimer;
    bool mCanRun = false;

    KeyCode mRunKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        mRunTimer = mStartRunTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Player runs when 
        if (Input.GetKey(mRunKey) && mRunTimer > 0.0f && mCanRun)
        {
            Run();
        }
        else
        {
            Walk();
        }

        if (transform.position.y < -10.0f)
        {
            ScoreManager.Lose();
        }
    }

    void Run()
    {
        Debug.Log("is Running");
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * mRunSpeed * Time.deltaTime;
        mRunTimer -= Time.deltaTime;
        if (mRunTimer <= 0.0f)
        {
            mCanRun = false;
        }
    }

    void Walk()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * mSpeed * Time.deltaTime;
        //Recharge the run time
        mRunTimer += Time.deltaTime;
        //wait until running is fully recharged before being able to run again
        if (mRunTimer >= mStartRunTime)
        {
            mRunTimer = mStartRunTime;
            mCanRun = true;
        }
    }
}
