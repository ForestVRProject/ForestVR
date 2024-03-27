using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTrigger = false;
    public int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (count == 0)
        {
            isTrigger = true;
            count++;
            if (this.gameObject.name == "BTrigger")
            {
                Butterfly.instance.following = false;
            }
        }
    }
}
