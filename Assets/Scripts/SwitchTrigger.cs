using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SwtichTrigger script is attached");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //test
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    _target.SendMessage("OpenDoor");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _target.SendMessage("OpenDoor");
        }
    }
}
