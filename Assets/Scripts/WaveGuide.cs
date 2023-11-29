using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGuide : MonoBehaviour
{
    AudioSource aus;
    public AudioSource singAus;
    public AudioClip singingball;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        aus = GetComponent<AudioSource>();
        StartCoroutine(Meditation());
    }

    IEnumerator Meditation()
    {
        aus.Play();
        yield return new WaitForSeconds(336);
        aus.Pause();
        singAus.PlayOneShot(singingball);
        yield return new WaitForSeconds(10);
        singAus.PlayOneShot(singingball);
        yield return new WaitForSeconds(10);
        singAus.PlayOneShot(singingball);
        yield return new WaitForSeconds(10);
        singAus.PlayOneShot(singingball);
        yield return new WaitForSeconds(10);
        singAus.PlayOneShot(singingball);
        yield return new WaitForSeconds(10);
        singAus.PlayOneShot(singingball);
        yield return new WaitForSeconds(10);
        Destroy(trigger);
        aus.Play();
    }
}
