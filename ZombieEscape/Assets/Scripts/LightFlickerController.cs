using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerController : MonoBehaviour
{
    public float minIntensityChange;
    public float maxIntensityChange;
    public float minDelay;
    public float maxDelay;

    private Light lightComp;
    private bool turningOn;

    void Start()
    {
        lightComp = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    //void Update()
    //{
    //    if (!turningOn)
    //    {
    //        lightComp.intensity -= Random.Range(minIntensityChange, maxIntensityChange);
    //        if (lightComp.intensity <= 0)
    //            turningOn = true;
    //    }
    //    if (turningOn)
    //    {
    //        lightComp.intensity += Random.Range(minIntensityChange, maxIntensityChange);
    //        if (lightComp.intensity >= 1)
    //            turningOn = false;
    //    }
    //}

    IEnumerator Flicker()
    {
        while (true)
        {
            if (!turningOn)
            {
                lightComp.intensity -= Random.Range(minIntensityChange, maxIntensityChange);
                if (lightComp.intensity <= 0)
                {
                    turningOn = true;
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                }
                yield return null;
            }
            else if (turningOn)
            {
                lightComp.intensity += Random.Range(minIntensityChange, maxIntensityChange);
                if (lightComp.intensity >= 1)
                {
                    turningOn = false;
                    yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
                }
                yield return null;
            }
        }
    }
}
