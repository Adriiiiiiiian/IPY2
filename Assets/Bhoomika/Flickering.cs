using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public Light lightFlickerVFX;

    public float minLightTime;
    public float maxLightTime;
    public float lightTimer;
    // Start is called before the first frame update
    void Start()
    {
        lightTimer = Random.Range(minLightTime, maxLightTime);
    }

    // Update is called once per frame
    void Update()
    {
        LightsAreFlickering();
    }

    void LightsAreFlickering()
    {
        if (lightTimer > 0)
        {
            lightTimer -= Time.deltaTime;
        }
        if (lightTimer <= 0)
        {
            lightFlickerVFX.enabled = !lightFlickerVFX.enabled;
            lightTimer = Random.Range(minLightTime, maxLightTime);
        }
    }
}
