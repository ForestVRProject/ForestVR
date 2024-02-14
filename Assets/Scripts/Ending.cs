using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Image blackout;
    float time_fade = 0f;
    [SerializeField] float F_time;

    private void Start()
    {
        StartCoroutine(FadeOutFlow());
    }
    private IEnumerator FadeOutFlow()
    {
        Color alpha = blackout.color;
        alpha.a = 1;
        blackout.gameObject.SetActive(true);

        while (alpha.a > 0)
        {
            time_fade += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time_fade);
            blackout.color = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
    }

}
