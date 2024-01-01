using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Image blackout;
    float time_fade = 0f;
    [SerializeField] float F_time;

    private IEnumerator FadeInFlow()
    {
        Color alpha = blackout.color;
        alpha.a = 0;
        blackout.gameObject.SetActive(true);

        while (alpha.a < 1f)
        {
            time_fade += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time_fade);
            blackout.color = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(FadeInFlow());
        }
    }
}
