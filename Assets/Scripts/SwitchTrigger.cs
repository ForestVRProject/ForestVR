using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameController")
        {
            _target.SendMessage("OpenDoor");
        }
    }
}
