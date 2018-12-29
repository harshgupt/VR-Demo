using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour {

    public GameObject camParent;

    private void Update()
    {
        transform.LookAt(camParent.transform);
    }
}
