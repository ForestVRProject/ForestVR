using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Guide.instance.isFirstFloor = true;
    }
}
