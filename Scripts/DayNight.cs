using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour
{

    [Range(0, 10)]
    public float MaxLightLevel;
    
    private int dayLength;   //in minutes
    private int dayStart;
    private int nightStart;   //also in minutes
    private int currentTime;
    public float cycleSpeed;
    private bool isDay;
    public int hours;
    public int minutes;
    private Vector3 sunPosition;
    public Light sun;
    public Light playervision;
    public GameObject earth;

    private double lightincrement;

    // Day and Night Script for 2d,
    // Unity needs one empty GameObject (earth) and one Light (sun)
    // make the sun a child of the earth
    // reset the earth position to 0,0,0 and move the sun to -200,0,0
    // attach script to sun
    // add sun and earth to script publics
    // set sun to directional light and y angle to 90


    void Start()
    {
        dayLength = 1440;
        dayStart = 300;
        nightStart = 1200;
        currentTime = 720;
        //MaxLightLevel = 1.5f;
        StartCoroutine(TimeOfDay());
        earth = gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        lightincrement = (MaxLightLevel - 0.0f / (1.0f / cycleSpeed)) * 0.001f;


        if (currentTime > 0 && currentTime < dayStart)
        {
            for (int i = 0; i < 2; i++)
            {
                sun.intensity = sun.intensity - (MaxLightLevel - 0.0f / (1.0f / cycleSpeed)) * 0.001f;
                playervision.range = playervision.range + 0.01f;

                if (sun.intensity <= 0.1f)
                {
                    sun.intensity = 0.0f;
                }

                if (playervision.range >= 10.0f)
                {
                    playervision.range = 10.0f;
                }
            }
        }
        else if (currentTime >= dayStart && currentTime < nightStart)
        {
            for (int i = 0; i < 2; i++)
            {
                sun.intensity = sun.intensity + (MaxLightLevel - 0.0f / (1.0f / cycleSpeed)) * 0.001f;
                playervision.range = playervision.range - 0.02f;

                if (sun.intensity >= MaxLightLevel) //Max light level
                {
                    sun.intensity = MaxLightLevel;
                }

                if (playervision.range <= 0.1f)
                {
                    playervision.range = 0.0f;
                }
            }
        }
        else if (currentTime >= nightStart && currentTime < dayLength)
        {
            for (int i = 0; i < 2; i++)
            {
                sun.intensity = sun.intensity - (MaxLightLevel - 0.0f / (1.0f / cycleSpeed)) * 0.001f;
                playervision.range = playervision.range + 0.01f;

                if (sun.intensity <= 0.1f)
                {
                    sun.intensity = 0.0f;
                }

                if (playervision.range >= 10.0f)
                {
                    playervision.range = 10.0f;
                }
            }
        }
        else if (currentTime >= dayLength)
        {
            currentTime = 0;
        }
        float currentTimeF = currentTime;
        float dayLengthF = dayLength;
        earth.transform.eulerAngles = new Vector3(0, 0, (-(currentTimeF / dayLengthF) * 360) + 90);
    }

    IEnumerator TimeOfDay()
    {
        while (true)
        {
            currentTime += 1;
            hours = Mathf.RoundToInt(currentTime / 60);
            minutes = currentTime % 60;
            yield return new WaitForSeconds(1F / cycleSpeed);
        }
    }
}
