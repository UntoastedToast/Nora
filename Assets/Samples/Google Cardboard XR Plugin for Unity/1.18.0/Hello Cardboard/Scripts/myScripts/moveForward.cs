using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{

    //public GameObject Spot2;
    // Start is called before the first frame update
    void Start()
    {
        //Spot2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.W))  
        {  
            transform.Translate(0.0f, 0f, 0.1f);  
        } 
    }
    public void OnPointerClick()
    {
        //Spot2.SetActive(true);
        transform.Translate(0.0f, 0f, 0.1f);
        
    }
}
