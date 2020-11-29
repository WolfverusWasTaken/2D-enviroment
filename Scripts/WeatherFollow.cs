using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    private float smoothspeed = 10f;

    public bool WeatherRain;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        smoothedPosition[2] = -15;
        transform.position = smoothedPosition;

    }
}
