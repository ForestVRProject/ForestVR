using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGuide : MonoBehaviour
{

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("enter");
                Guide.instance.isElevator = true;
            }
        }
}
