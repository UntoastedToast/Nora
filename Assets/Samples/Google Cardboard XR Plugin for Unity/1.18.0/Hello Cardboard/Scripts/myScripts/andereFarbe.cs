using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class andereFarbe : MonoBehaviour
{
    public GameObject Spot1;
    public Material[] material;
    public int x;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        x=0;
        rend = GetComponent<Renderer>();
        rend.enabled =true;
        rend.sharedMaterial = material[x];

        Spot1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];

        // if (Input.GetKeyDown(KeyCode.Space)){x++;}
    }
    
    public void OnPointerEnter()
    {
        x++;
        Spot1.SetActive(true);
    }
    public void OnPointerExit()
    {
        x--;
        Spot1.SetActive(false);
    }
    public void OnPointerClick()
    {
        x++;
        Spot1.SetActive(true);
    }
    

    public void Nextcolor()
    {
        if(x<2)
        {
            x++;
        }
        else
        {
           x = 0; 
        }
    }
}
