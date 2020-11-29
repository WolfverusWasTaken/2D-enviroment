using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTemp : MonoBehaviour
{

    public Transform Rain;
    public Transform Cloud;

    public Light sun;

    public double CurrentTemperature;
    public double minTemp;
    public double maxTemp;

    //public double RainPercent;
    
    public float LightLevel;
    public double humidity;

    public int waitTime;

    [Range(1, 3)]
    public float humidgainspeed;


    private double avgtemp;
    private bool humidgain;
    private bool humidcoold;

    // Start is called before the first frame update
    void Start()
    {
        avgtemp = (minTemp + maxTemp) / 2;
        humidgain = true;
        //humidcoold = false;

        humidgainspeed = 1;

        StartCoroutine(humiditygain());

    }

    // Update is called once per frame
    void Update()
    {
        LightLevel = (sun.intensity/1.5f)*100; //update light level in precent

        updatetemperature(); //will update temperature depending on time
        humiditygain(); //will increase humidity

    }

    void updatetemperature()
    {
        if (LightLevel <= 50)
        {
            CurrentTemperature = ((LightLevel / 100) * minTemp * 0.5) + minTemp;
        }

        if (LightLevel > 50)
        {
            CurrentTemperature = ((LightLevel / 100) * maxTemp * 0.3) + maxTemp;
        }
    }

    IEnumerator humiditygain()
    {
        while (true)
        {
            if (humidgain)
            {
                humidity += CurrentTemperature / 1000;

                if (humidity >= 1.5)
                {
                    humidity = 1.5;
                    humidgain = false;
                }

                
            }
            else if (humidgain == false)
            {
                humidity -= 0.01;
                Rain.GetComponent<ParticleSystem>().enableEmission = true;

                if (humidity <= 0.05)
                {
                    humidity = 0.0;
                    humidgain = true;
                    Rain.GetComponent<ParticleSystem>().Stop();
                    Rain.GetComponent<ParticleSystem>().enableEmission = false;
                }
            }



            yield return new WaitForSeconds(1 / humidgainspeed);
        }
    }


}
