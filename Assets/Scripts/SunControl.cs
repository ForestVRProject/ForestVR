using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControl : MonoBehaviour
{
    public Material defaultSkyMat;
    //public Material eveningSkyMat;
    public Light directionalLight;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = defaultSkyMat;
        RenderSettings.skybox.SetColor("_Tint", new Color32(128, 128, 128, 255));
        StartCoroutine(SunMove());
    }

    IEnumerator SunMove()
    {
        yield return new WaitForSeconds(3);
        RenderSettings.skybox.SetColor("_Tint", new Color32(128, 128, 90, 255));
        yield return new WaitForSeconds(3);
        RenderSettings.skybox.SetColor("_Tint", new Color32(255, 128, 60, 255));
        directionalLight.color = new Color32(201, 109, 127, 255);
        yield return new WaitForSeconds(3);
        RenderSettings.skybox.SetColor("_Tint", new Color32(100, 50, 30, 255));
        yield return new WaitForSeconds(3);
        //RenderSettings.skybox = eveningSkyMat;
        directionalLight.color = new Color32(87, 68, 111, 255);
    }

    private void FixedUpdate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * -1.5f);
    }
}
