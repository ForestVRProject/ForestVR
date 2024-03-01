using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public static Butterfly instance;
    public Transform target;
    public bool following = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated Butterfly, ignoring this one", gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void LateUpdate()
    {
        this.transform.LookAt(target.transform);
    }

    void FollowTarget()
    {
        if(Vector3.Distance(target.position, this.transform.position) > 1 && following)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, 1*Time.deltaTime);
        }
    }
}
