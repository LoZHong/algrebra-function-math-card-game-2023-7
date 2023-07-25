using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingNum : MonoBehaviour
{

    public bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isTriggered = true;
        }
    }
}
