using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetection : MonoBehaviour {
    
    public Camera camLeft;
    public Camera camRight;

    public GameObject camParent;
    public GameObject interactableObject;
    public GameObject objectMenu;

    RaycastHit hit;

    public Image loadFillLeft;
    public Image loadFillRight;

    Material cubeMaterial;

    bool incColor = true;
	
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
                        objectMenu.SetActive(true);
                    }
                    else if(hit.collider.gameObject.tag == "TeleportPlatform")
                    {
                        TeleportToPlatform(hit.collider.gameObject.name);
                    }
                }
            }
            else if(hit.collider.gameObject.tag == "UI")
            {
                switch (hit.collider.gameObject.name)
                {
                    case "ScaleUp":
                        ScaleObjectUp();
                        break;
                    case "ScaleDown":
                        ScaleObjectDown();
                        break;
                    case "RotateX":
                        RotateObjectX();
                        break;
                    case "RotateY":
                        RotateObjectY();
                        break;
                    case "RotateZ":
                        RotateObjectZ();
                        break;
                    case "ChangeColor":
                        //Functions to change color continuously
                        if (incColor)
                        {
                            ChangeColorUp();
                        }
                        else
                        {
                            ChangeColorDown();
                        }
                        break;
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

    void ScaleObjectUp()
    {
        Vector3 scaleVal = new Vector3(0.01f, 0.01f, 0.01f);
        if(interactableObject.transform.localScale.x <= 4f || interactableObject.transform.localScale.y <= 4f || interactableObject.transform.localScale.z <= 4f)
        {
            interactableObject.transform.localScale += scaleVal;
        }
    }

    void ScaleObjectDown()
    {
        Vector3 scaleVal = new Vector3(0.01f, 0.01f, 0.01f);
        if (interactableObject.transform.localScale.x >= 1f || interactableObject.transform.localScale.y >= 1f || interactableObject.transform.localScale.z >= 1f)
        {
            interactableObject.transform.localScale -= scaleVal;
        }
    }

    void RotateObjectX()
    {
        interactableObject.transform.Rotate(0.5f, 0, 0);
    }

    void RotateObjectY()
    {
        interactableObject.transform.Rotate(0, 0.5f, 0);
    }

    void RotateObjectZ()
    {
        interactableObject.transform.Rotate(0, 0, 0.5f);
    }

    void ChangeColorUp()
    {
        Color currentColor = interactableObject.GetComponent<Renderer>().material.color;
        if(currentColor.r >= 1)
        {
            if(currentColor.b >= 1)
            {
                if(currentColor.g >= 1)
                {
                    incColor = false;
                    ChangeColorDown();
                }
                else
                {
                    currentColor.g += 0.01f;
                }
            }
            else
            {
                currentColor.b += 0.01f;
            }
        }
        else
        {
            currentColor.r += 0.01f;
        }
        interactableObject.GetComponent<Renderer>().material.color = currentColor;
    }
    void ChangeColorDown()
    {
        Color currentColor = interactableObject.GetComponent<Renderer>().material.color;
        if (currentColor.r <= 0)
        {
            if (currentColor.b <= 0)
            {
                if (currentColor.g <= 0)
                {
                    incColor = true;
                    ChangeColorUp();
                }
                else
                {
                    currentColor.g -= 0.01f;
                }
            }
            else
            {
                currentColor.b -= 0.01f;
            }
        }
        else
        {
            currentColor.r -= 0.01f;
        }
        interactableObject.GetComponent<Renderer>().material.color = currentColor;
    }
}
