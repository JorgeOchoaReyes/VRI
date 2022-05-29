using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DwellTimeControls : MonoBehaviour
{
    public Transform rayTransform;
    public OVRInput.Button joyPadClickButton = OVRInput.Button.One;
    public bool pressed;
    public bool released; 
    public Color defaultColor; 
    public GameObject gazepointer;
    public Ray ray;
    public RaycastHit hit;
    public float dwellTime;
    public float dwellLimit; 

    void Start()
    {
        rayTransform = Camera.main.transform;
        gazepointer = GameObject.FindGameObjectWithTag("DwellTimePort");
        dwellTime = 0f;
        defaultColor = Color.red; 
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

        float slope = dwellTime / dwellLimit;
        float dxr = Color.green.r - Color.red.r;
        float dxg = Color.green.g - Color.red.g;
        float dxb = Color.green.b - Color.red.b;
        float dxa = Color.green.a - Color.red.a;

        Color pointerColor = new Color();
        pointerColor.r = slope * dxr + Color.red.r;
        pointerColor.g = slope * dxg + Color.red.b;
        pointerColor.b = slope * dxb + Color.red.g;
        pointerColor.a = slope * dxa + Color.red.a;

        //Filter first by check whether we are looking at a clickable ui, then has time dwelled long enough? if so then trigger GetComponent<Button>().onClick

        //GameObject.Find("Button").transform.gameObject.GetComponent<Button>().onClick.Invoke();


        gazepointer.transform.gameObject.GetComponent<SpriteRenderer>().color = pointerColor; 

        if (dwellTime > dwellLimit)
        {
            gazepointer.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            dwellTime = 0f;
        }

        //if (Physics.Raycast(rayTransform.position, rayTransform.forward, out hit, Mathf.Infinity, layerMask))
        //{
        //    //Filer through hits here by using tags labeled ui so we only begin a countdown when hitting ui elements 
        //    circle.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //}

    }
}
