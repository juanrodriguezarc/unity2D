using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(45,0,0) * transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
