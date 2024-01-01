using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public static Guide instance;
    public AudioSource guideAud;
    public AudioClip startGuide;
    public AudioClip[] guide;
    public bool isElevator = false;
    public bool isFirstFloor = false;
    public int i = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Duplicated Guide, ignoring this one",gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4");
            guideAud.clip = elevator[index];
            guideAud.Play();
            index++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("5");
            Player.instance.GetUserVoice();
        }
    }*/

    public void StartGuide()
    {
        StartCoroutine(GuideStart());
    }

    public IEnumerator GuideStart()
    {
        guideAud.clip = startGuide;
        guideAud.Play();
        yield return new WaitForSeconds(77.5f);
        guideAud.Pause();
        yield return new WaitUntil(() => isElevator == true);
        guideAud.Play();
        yield return new WaitForSeconds(80.5f);
        guideAud.Pause();
        yield return new WaitUntil(() => isFirstFloor == true);
        guideAud.Play();
    }

    public void GuideSwitch()
    {
        guideAud.clip = guide[i];
        guideAud.Play();
        i++;
    }
}
