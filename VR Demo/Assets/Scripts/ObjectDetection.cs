using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetection : MonoBehaviour {

    //Approximating the object looked at, is from the left camera
    public Camera cam;

    RaycastHit hit;

    public Image loadFillLeft;
    public Image loadFillRight;

    //Bool to prevent multiple calls of the function within update, while looking at an object
    bool lookingAtObject = false;
	
	void Update ()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            //Debug.Log(lookingAtObject);
            if(hit.collider.gameObject.tag == "InteractableObject" || hit.collider.gameObject.tag == "TeleportPlatform")
            {
                loadFillLeft.fillAmount += 0.01f;
                loadFillRight.fillAmount += 0.01f;
                if (!lookingAtObject)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    lookingAtObject = true;
                }
            }
            else
            {
                loadFillLeft.fillAmount = 0f;
                loadFillRight.fillAmount = 0f;
                //Debug.Log(hit.collider.gameObject.name);
                lookingAtObject = false;
            }
        }
	}
}
