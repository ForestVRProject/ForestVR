using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform _origin, _target; // elevator waypoints
    [SerializeField] private float _speed = 3.0f;
    private GameObject _switch;
    public Animation leftDoor;
    public Animation rightDoor;

    private bool _goingDown = true;



    private void Start()
    { 
    }
    public void CallElevator()
    {
        _goingDown = !_goingDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_goingDown == true) 
        {
            Vector3 direction = _target.position - transform.position;

            float distance = direction.magnitude;

            if (distance > 0.1f)
            {
                Vector3 moveAmount = direction.normalized * _speed * Time.fixedDeltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target.position, moveAmount.magnitude);
            }
        }
        //if (_goingDown == true)
        //{     
        //    this.transform.position = Vector3.MoveTowards(this.transform.position, _target.position, _speed * Time.deltaTime);
        //}
        //else if (_goingDown == false)
        //{
        //    this.transform.position = Vector3.MoveTowards(this.transform.position, _origin.position, _speed * Time.deltaTime);
        //}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // test with MainCamera
        {     
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") // test with MainCamera
        {
            other.transform.parent = null;
        }
    }

    private void OpenDoor()
    {
        if(leftDoor == null || rightDoor == null)
        {
            Debug.LogError("left door or right door is null");
            return;
        }

        leftDoor.Play("OpenLeftDoor");
        rightDoor.Play("OpenRightDoor");
    }

}
