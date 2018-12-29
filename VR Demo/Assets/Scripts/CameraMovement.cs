using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Camera camLeft;
    public Camera camRight;

    public GameObject camParent;

    private Quaternion rot;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        camParent.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        rot = new Quaternion(0, 0, 1, 0);
    }

    private void Update()
    {
        camLeft.transform.localRotation = Input.gyro.attitude * rot;
        camRight.transform.localRotation = Input.gyro.attitude * rot;
    }
}
