using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObejctFixed : MonoBehaviour
{
    public int y = 0;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}
