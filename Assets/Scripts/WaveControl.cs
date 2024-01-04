using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0.2f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Time.timeScale = 1;
        }
    }
}
