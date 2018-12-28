using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetection : MonoBehaviour {
    
    public Camera camLeft;
    public Camera camRight;

    public GameObject camParent;
    public GameObject objectMenu;

    RaycastHit hit;

    public Image loadFillLeft;
    public Image loadFillRight;
	
	void Update ()
    {
        if(Physics.Raycast(camLeft.transform.position, camLeft.transform.forward, out hit) || Physics.Raycast(camRight.transform.position, camRight.transform.forward, out hit))
        {
            if(hit.collider.gameObject.tag == "InteractableObject" || hit.collider.gameObject.tag == "TeleportPlatform")
            {
                //Debug.Log(hit.collider.gameObject.name);
                loadFillLeft.fillAmount += 0.01f;
                loadFillRight.fillAmount += 0.01f;
                if(loadFillLeft.fillAmount >= 1 || loadFillRight.fillAmount >= 1)
                {
                    if(hit.collider.gameObject.tag == "InteractableObject")
                    {

                    }
                    else if(hit.collider.gameObject.tag == "TeleportPlatform")
                    {
                        TeleportToPlatform(hit.collider.gameObject.name);
                    }
                }
            }
            else
            {
                loadFillLeft.fillAmount = 0f;
                loadFillRight.fillAmount = 0f;
            }
        }
	}

    void TeleportToPlatform(string platformName)
    {
        Vector3 newPos;
        switch (platformName)
        {
            case "Platform1":
                newPos = new Vector3(0, 7f, -10f);
                camParent.transform.position = newPos;
                break;
            case "Platform2":
                newPos = new Vector3(10f, 7f, 10f);
                camParent.transform.position = newPos;
                break;
            case "Platform3":
                newPos = new Vector3(-10f, 7f, 10f);
                camParent.transform.position = newPos;
                break;
            default:
                break;
        }
    }
}
