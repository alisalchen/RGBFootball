using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 mOffset = new Vector3(0.0f, 3.0f, -15.0f);
    Vector3 mSmoothSpeed = new Vector3(2.0f, 2.0f, 2.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPos = new Vector3(target.position.x + mOffset.x, target.position.y + mOffset.y, target.position.z + mOffset.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref mSmoothSpeed, 0.2f);
    }
}
