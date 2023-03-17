using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GazeTiming : MonoBehaviour
{
    //auf PickUp zugreifen
    public PickUp PickUp;
    //

    public Image imgGaze;
    public Image BriefBild;

    public AudioSource source;
    public AudioClip clip;
    
    const float nSecond = 2f;
    float timer = 0;
    bool entered = false;
    bool timerTriggered = false;
    
    public float totalTime = 2;

    //Teleport
    public GameObject player;
    public int distanceOfRay = 10;
    private RaycastHit _hit;
    //Teleport
   
    public void Start()
    {
        //Debug.Log(imgGaze);
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

            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Untagged"))
            {
                if (source.isPlaying)
            {
                source.Stop();
            }
               source.PlayOneShot(clip);
               timerTriggered = true;
            }

            //Brief
            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Brief"))
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.PlayOneShot(clip);
                BriefBild.fillAmount = 1; // Set fill amount to 1
                StartCoroutine(ResetFillAmountAfterDelay(20f)); // Reset fill amount after 5 seconds
                timerTriggered = true;
            }


            //Load every Level
            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("NextLevel1"))
            {
                SceneManager.LoadScene("Level1");
            }
            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("NextLevel2"))
            {
                SceneManager.LoadScene("Level2");
            }
            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("NextLevel3"))
            {
                SceneManager.LoadScene("Level3");
            }
            //Abgeegte Objekte
            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Ablage1") && PickUp.inHands)
            {
                SceneManager.LoadScene("Level2");
            }
            else if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Ablage1"))
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.PlayOneShot(clip);
                timerTriggered = true;
            }
            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Ablage2") && PickUp.inHands)
            {
                SceneManager.LoadScene("Level3");
            }
            else if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Ablage2"))
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.PlayOneShot(clip);
                timerTriggered = true;
            }
            if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Ablage3") && PickUp.inHands)
            {
                SceneManager.LoadScene("Level4");
            }
            else if (timer > nSecond && !timerTriggered && _hit.transform.CompareTag("Ablage3"))
            {
                if (source.isPlaying)
                {
                    source.Stop();
                }
                source.PlayOneShot(clip);
                timerTriggered = true;
            }
        }
        else
        {
            timer = 0;
            timerTriggered = false;
                     
        }


        //Teleport
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                //Debug.Log("teleportier");
                _hit.transform.gameObject.GetComponent<Telep>().TeleportPlayer();
            }
        }
        //Teleport



    }

    IEnumerator ResetFillAmountAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    BriefBild.fillAmount = 0; // Set fill amount back to 0
}
}