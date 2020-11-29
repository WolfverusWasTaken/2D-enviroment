using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool FollowTarget;

    public Transform Target;

    public float smoothspeed = 0.1f;
    public Vector3 offset;

    void FixedUpdate()
    {
        if (FollowTarget)
        {
            Vector3 desiredPosition = Target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
            smoothedPosition[2] = -20; //z axis
            transform.position = smoothedPosition;
        }
    }
}
