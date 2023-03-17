using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VoiceOverScene : MonoBehaviour
{
    //Audioclips
    public AudioSource source;
    public AudioClip Minute1;
    public AudioClip Minute2;
    public AudioClip Minute3;

    //Timer
    float masterTimer = 0;
    float timerFirstMinute = 1;
    float timerSecondMinute = 20;
    float timerThirdMinute = 27;
    float NextSceneMinute = 32;

    //wurde der sound schon abgespielt?
    bool audio1Played = false;
    bool audio2Played = false; 
    bool audio3Played = false; 

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Timer started");

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            timerFirstMinute = 0;
            timerSecondMinute = 6;
            timerThirdMinute = 21;
            NextSceneMinute = 30;
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            timerFirstMinute = 1;
            timerSecondMinute = 7;
            timerThirdMinute = 17;
            NextSceneMinute = 27;
        }

    }

    // Update is called once per frame
    void Update()
    {
        masterTimer += Time.deltaTime;

        if(masterTimer > timerFirstMinute && !audio1Played)
        {
            if (source.isPlaying)
                {
                    source.Stop();
                }
            source.PlayOneShot(Minute1);
            audio1Played = true;
        }
        if(masterTimer > timerSecondMinute && !audio2Played)
        {
            if (source.isPlaying)
                {
                    source.Stop();
                }
            source.PlayOneShot(Minute2);
            audio2Played = true;
        }
        if(masterTimer > timerThirdMinute && !audio3Played)
        {
            if (source.isPlaying)
                {
                    source.Stop();
                }
            source.PlayOneShot(Minute3);
            audio3Played = true;
        }
        if(masterTimer > NextSceneMinute && SceneManager.GetActiveScene().name == "LevelIntro"){
            SceneManager.LoadScene("Level0");
        }
        
    }
}
