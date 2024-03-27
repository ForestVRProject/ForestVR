using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Elevator : MonoBehaviour
{
    public static Elevator instance;
    [SerializeField] private Transform _origin, _target; // elevator waypoints
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private GameObject _player;
    private AudioSource _audioSource;
    public Animation leftDoor;
    public Animation rightDoor;

    public bool _goingDown = false;
    public bool _goingUp = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated Elevator, ignoring this one", gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("ElevatorMoving script is attached");
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_goingDown) 
        {
            Vector3 direction = _target.position - transform.position;

            float distance = direction.magnitude;

            if (distance > 0.1f)
            {              
                Vector3 moveAmount = direction.normalized * _speed * Time.fixedDeltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _target.position, moveAmount.magnitude);
            }
            else
            {
                _goingDown = false;
                _audioSource.Stop();
                OpenDoor();
                Butterfly.instance.ChangeTarget();
            }
        }else if (_goingUp)
        {
            Vector3 direction = _origin.position - transform.position;

            float distance = direction.magnitude;

            if (distance > 0.1f)
            {
                Vector3 moveAmount = direction.normalized * _speed * Time.fixedDeltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _origin.position, moveAmount.magnitude);
            }
            else
            {
                _goingUp = false;
                _audioSource.Stop();
                OpenDoor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {    
        if(other.tag == "Player")
        {
            Debug.Log("enter elevator");
            CloseDoor();
            _player.transform.parent = this.transform;
            if(!_goingDown && !_goingUp)
            {
                Invoke("CloseAnimationEnd", 2);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("exit elevator");
            _player.transform.parent = null;
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        if(leftDoor != null && rightDoor != null && !_goingDown && !_goingUp)
        {
            leftDoor.Play("OpenLeftDoor");
            rightDoor.Play("OpenRightDoor");
        }
    }

    private void CloseDoor()
    {
        if (leftDoor != null && rightDoor != null && !_goingDown && !_goingUp)
        {
            leftDoor.Play("CloseLeftDoor");
            rightDoor.Play("CloseRightDoor");
        }
    }

    public void CloseAnimationEnd()
    {
        Vector3 directionToOrigin = _origin.position - transform.position;
        Vector3 directionToTarget = _target.position - transform.position;


        float distanceToOrigin = directionToOrigin.magnitude;
        float distanceToTarget = directionToTarget.magnitude;

        if(distanceToOrigin < distanceToTarget)
        {
            Debug.Log("Going Down");
            _goingDown = true;
            _audioSource.Play();
        }
        else
        {
            Debug.Log("Going Up");
            _goingUp = true;
            _audioSource.Play();
        }
    }
}
