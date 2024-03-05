using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innerchild : MonoBehaviour
{
    public Light ilight;
    public bool boy;
    public bool changed = false;
    public bool hug = false;
    public bool ishug = false;
    private bool change = false;
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
        this.change = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (change)
        {
            ilight.color = new Color32(255, 0, 170, 255);
            changed = true;
        }
        if (ishug)
        {
            hug = true;
        }
    }

    public void FadeOut()
    {
        ishug = true;
        StartCoroutine(Hug());
    }

    IEnumerator Hug()
    {
        yield return new WaitUntil(() => hug);
        Destroy(gameObject,3);
    }
}
