using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaTrigger : MonoBehaviour
{
    public AudioSource source;
    public AudioClip collisionClip;

    public float cooldownDuration = 0f;
    float cooldownTimer = 6;

    private void OnTriggerEnter(Collider other)
    {
        if (cooldownTimer >= cooldownDuration)
        {
            Debug.Log("Collider working");
            source.PlayOneShot(collisionClip);
            cooldownTimer = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            source.Stop();
        
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
}