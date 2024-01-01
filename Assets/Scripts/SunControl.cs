using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControl : MonoBehaviour
{
    public Material defaultSkyMat;
    public Material sunsetSkyMat;
    public Material eveningSkyMat;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = defaultSkyMat;
        StartCoroutine(SunMove());
    }

    IEnumerator SunMove()
    {
        yield return new WaitForSeconds(9);
        RenderSettings.skybox = sunsetSkyMat;
        yield return new WaitForSeconds(9);
        RenderSettings.skybox = eveningSkyMat;
    }
}
