using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothFactor;

    public bool lockY;

    private float Y;
    private void Start()
    {
        Y = transform.position.y;
    }
    private void FixedUpdate()
    {
        Follow();    
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
        if(lockY)
            transform.position = new Vector3(transform.position.x, Y, transform.position.z);
    }
}