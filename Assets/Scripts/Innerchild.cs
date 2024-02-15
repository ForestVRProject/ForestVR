using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innerchild : MonoBehaviour
{
    public bool boy;
    // Start is called before the first frame update
    void Start()
    {
        if (Guide.instance.isGirl && boy)
        {
            Destroy(this.gameObject);
        }
        else if(!Guide.instance.isGirl && !boy)
        {
            Destroy(this.gameObject);
        }
    }

}
