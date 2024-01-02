using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [Tooltip("ด๋ป็")]
    [SerializeField]
    private string[] textdata;
    public int i = 0;
    public TextMeshProUGUI textShow;

    private void Start()
    {
        Invoke("StartText", 3f);
    }

    public void StartText()
    {
        StartCoroutine(SwitchText());
    }

    IEnumerator SwitchText()
    {
        while (true)
        {
            Guide.instance.GuideSwitch();
            textShow.SetText(textdata[i]);
            yield return new WaitWhile(()=> Guide.instance.guideAud.isPlaying == true);
            i++;
            yield return new WaitForSeconds(1);
        }
    }
}
