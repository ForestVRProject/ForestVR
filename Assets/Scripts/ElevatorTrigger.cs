using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] private Transform _origin, _target;
    [SerializeField] private float _speed;
    public Animation leftDoor2f;
    public Animation rightDoor2f;

    private bool _goingUp = false;

    private void Start()
    {
        leftDoor2f = GameObject.Find("left_door2f").GetComponent<Animation>();
        rightDoor2f = GameObject.Find("right_door2f").GetComponent<Animation>();
    }

    public void CallElevator()
    {
        _goingUp = !_goingUp;
    }

    private void FixedUpdate()
    {
        if(_goingUp == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _origin.position, _speed * Time.deltaTime);
            leftDoor2f.Play("OpenLeftDoor");
            rightDoor2f.Play("OpenRightDoor");

        }
        else if(_goingUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _goingUp = !_goingUp;
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
    
}
