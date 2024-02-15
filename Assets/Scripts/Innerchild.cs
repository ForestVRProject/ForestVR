using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innerchild : MonoBehaviour
{
    public Light ilight;
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
        ilight.color = new Color32(255, 248, 4, 255);
    }

    public void ChangeColor()
    {
        ilight.color = new Color32(255, 0, 170, 255);
    }

}
