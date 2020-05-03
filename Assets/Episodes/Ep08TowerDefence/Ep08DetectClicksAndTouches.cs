//Copyright 2012 Maximilian Wolfgang Maroe, feel free to use or modify this script at your leisure
//This script sets it up so that when you click or touch, it tries to find an object in the scene
//that is in the direction of where you clicked, and sends a "Clicked()" message to the object.
//Supports touch (And multitouch!)

using UnityEngine;

public class Ep08DetectClicksAndTouches : MonoBehaviour
{
    //This variable is optional; if not set it will default to the main camera
    //This is so that you can detect clicks/touches on a separate UI Camera
    //This variable does NOT update in real time
    public Camera detectionCamera;

    //This variable adds a Debug.Log call to show what was touched
    public bool debug = false;

    //This is the actual camera we reference in the update loop, set in Start()
    private Camera _camera;

    void Start()
    {
        _camera = detectionCamera != null ? detectionCamera : Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;

        //Left Click
        if (Input.GetMouseButtonDown(0)) //Check to see if we've clicked
        {
            //Set up our ray from screen to scene
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            //If we hit...
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Tell the system what we clicked something if in debug
                if (debug)
                {
                    Debug.Log("You clicked " + hit.collider.gameObject.name, hit.collider.gameObject);
                }

                //Run the Clicked() function on the clicked object
                hit.transform.gameObject.SendMessage("Clicked", hit.point, 
                    SendMessageOptions.DontRequireReceiver);
            }
        }

        //Right Click
        if (Input.GetMouseButtonDown(1)) //Check to see if we've clicked
        {
            //Set up our ray from screen to scene
            ray = _camera.ScreenPointToRay(Input.mousePosition);

            //If we hit...
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //Tell the system what we clicked something if in debug
                if (debug)
                {
                    Debug.Log("You right clicked " + hit.collider.gameObject.name, hit.collider.gameObject);
                }

                //Run the Clicked() function on the clicked object
                hit.transform.gameObject.SendMessage("RightClicked", hit.point, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}