using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telep : MonoBehaviour
{
    public GameObject player;
    int y = 0; 

    public void TeleportPlayer()
    {
        //Debug.Log("Tutorial");
        player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void OnPointerEnter()
    {
        y++;
    }

    public void OnPointerExit()
    {
        y++;
    }
}