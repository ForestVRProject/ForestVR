using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    private ElevatorTrigger _elevator;

    // Start is called before the first frame update
    void Start()
    {
        _elevator = GameObject.Find("elevator_interior1").GetComponent<ElevatorTrigger>();

        if (_elevator == null)
        {
            Debug.LogError("Elevator is Null");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _elevator.CallElevator();
        }
    }

}
