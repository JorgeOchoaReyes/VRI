using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject vri;
    Color transparent; 
    void Start()
    {
        vri = GameObject.Find("LeftPanel");
        transparent.r = 255;
        transparent.g = 0;
        transparent.b = 0;
        transparent.a = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        vri.transform.gameObject.GetComponent<MeshRenderer>().material.color = transparent; 
    }
}
