using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwellTimeControls : MonoBehaviour
{
    public Transform rayTransform;
    public OVRInput.Button joyPadClickButton = OVRInput.Button.One;
    public bool pressed;
    public bool released; 
    public Color defaultColor; 
    public GameObject circle;
    public Ray ray;
    public RaycastHit hit;
    public float dwellTime;
    public float dwellLimit; 

    void Start()
    {
        rayTransform = Camera.main.transform;
        circle = GameObject.FindGameObjectWithTag("DwellTimePort");
        dwellTime = 0f;
        dwellLimit = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        //These two bools need to be imported by the OVRInputModule script in the GetGazeButtonState
        pressed = OVRInput.GetDown(joyPadClickButton);
        released = OVRInput.GetUp(joyPadClickButton);

        dwellTime += Time.deltaTime;

        circle.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        if (dwellTime > dwellLimit)
        {
            circle.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            dwellTime = 0f;
        }

        //if (Physics.Raycast(rayTransform.position, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
        //{
        //    //Filer through hits here by using tags labeled ui so we only begin a countdown when hitting ui elements 
        //    circle.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //}

    }
}
