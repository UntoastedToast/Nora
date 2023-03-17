using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float minIntensity = 0.6f; // The minimum intensity of the light
    public float maxIntensity = 1.2f; // The maximum intensity of the light
    public float flickerSpeed = 0.3f; // The speed of the flicker

    private Light flameLight;

    void Start()
    {
        flameLight = GetComponent<Light>();
        InvokeRepeating("Flicker", 0, flickerSpeed);
    }

    void Flicker()
    {
        flameLight.intensity = Random.Range(minIntensity, maxIntensity);
    }
}