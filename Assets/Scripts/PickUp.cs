using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public Image imgGaze;

    //Timer für Gaze
    const float nSecond = 2f;
    float timer = 0;
    bool entered = false;
    bool timerTriggered = false;
    public float totalTime = 2;
    //Timer für Gaze

    //Taschenlampe
    public Transform copyRotationSource;
    public Transform taschenlampeRotation;
    public GameObject taschenlampe;
    public GameObject hand;
    public bool inHands;
    public GameObject TaschenLampenLicht;
    //Taschenlampe

    //Batterie
    float batterieTimer;
    bool batterieTimerTriggered;
    public float sound1 = 22;
    public float sound2 = 53;
    public float sound3 = 90;
    public Image ImageFull;
    public Image ImageMid;
    public Image ImageLow;
    //Batterie
   
    //sound
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;

    bool clip2Played = false;
    bool clip3Played = false;
    bool clip4Played = false;
    //
    public void Start()
    {
        imgGaze.fillAmount = 0;
    }

    public void OnPointerEnter()
    {
        entered = true;
    }

    public void OnPointerExit()
    {
        entered = false;
        imgGaze.fillAmount = 0;
    }

    void Update()
    {
        if (entered)
        {
            timer += Time.deltaTime;
            imgGaze.fillAmount = timer / totalTime;

            if (timer > nSecond && !timerTriggered)
            {
                /*Debug.Log("Taschenlampe aufgehoben");
                taschenlampe.transform.SetParent(hand.transform);
                taschenlampe.transform.localPosition = hand.transform.localPosition;
                inHands = true;
                TaschenLampenLicht.SetActive(true);
                //taschenlampe.transform.Rotate(0f, 90f, 0f);
                taschenlampeRotation.rotation = copyRotationSource.rotation;
                timerTriggered = true;*/

                Debug.Log("Object picked up");

                // set parent and local position of the object
                gameObject.transform.SetParent(hand.transform);
                gameObject.transform.localPosition = hand.transform.localPosition;

                // check tag of the object and rotate it accordingly
                if (gameObject.CompareTag("Quittung"))
                {
                    if (source.isPlaying)
                    {
                        source.Stop();
                    }
                    gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    source.PlayOneShot(clip);
                }
                else if (gameObject.CompareTag("Puppe"))
                {
                    if (source.isPlaying)
                    {
                        source.Stop();
                    }
                    gameObject.transform.localRotation = Quaternion.Euler(-90, 90, 90);
                    source.PlayOneShot(clip);
                }

                // set inHands flag to true
                inHands = true;
                timerTriggered = true;
                }
        }

        if (inHands)
        {
            batterieTimer += Time.deltaTime;

            if (batterieTimer >= sound1 && !clip2Played)
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.PlayOneShot(clip2);
                clip2Played = true;
            }
            if (batterieTimer >= sound2 && !clip3Played)
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.PlayOneShot(clip3);
                clip3Played = true;
            }
            if (batterieTimer >= sound3 && !clip4Played)
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.PlayOneShot(clip4);
                clip4Played = true;
            }
        }
    }
}
