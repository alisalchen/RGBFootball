using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallBehavior : MonoBehaviour
{
    public GameObject mPlayer;
    int mForceMultiplier = 200;

    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        //Generate a random ball from the list of potential balls
        BallData data = BallGenerator.mBallList.BallList[Random.Range(0, BallGenerator.mBallList.BallList.Count)];

        //Set the material to its respective color
        if (data.color.Equals("red"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (data.color.Equals("green"))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (data.color.Equals("blue"))
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        //Now set the ball in the direction towards the player
        Vector3 direction = (mPlayer.transform.position - transform.position).normalized;
        //launch the ball towards the player + upwards force in the positive y-direction
        GetComponent<Rigidbody>().AddForce((direction + new Vector3(0.0f, 1.0f, 0.0f)).normalized * data.velocity * mForceMultiplier);
    }

    void Update()
    {
        if (transform.position.y < -10.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit Player");
            ScoreManager.UpdateScore();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            ScoreManager.Lose();
        }
    }
}
