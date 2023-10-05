using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public static Guide instance;
    public AudioSource guideAud;
    public AudioClip elevator1;
    public AudioClip elevator2;
    public AudioClip elevator3;
    public AudioClip elevator4;
    public AudioClip elevator5;
    public AudioClip elevator6;
    public AudioClip elevator7;
    public AudioClip elevator8;
    public AudioClip elevator9;
    public AudioClip elevator10;
    public AudioClip elevator11;
    public AudioClip elevator12;
    public AudioClip elevator13;
    public AudioClip elevator14;
    public AudioClip elevator15;
    public AudioClip[] elevator;
    public int index = 0;

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
        elevator = new AudioClip[15];
        guideAud = GetComponent<AudioSource>();
        elevator.SetValue(elevator1, 0);
        elevator.SetValue(elevator2, 1);
        elevator.SetValue(elevator3, 2);
        elevator.SetValue(elevator4, 3);
        elevator.SetValue(elevator5, 4);
        elevator.SetValue(elevator6, 5);
        elevator.SetValue(elevator7, 6);
        elevator.SetValue(elevator8, 7);
        elevator.SetValue(elevator9, 8);
        elevator.SetValue(elevator10, 9);
        elevator.SetValue(elevator11, 10);
        elevator.SetValue(elevator12, 11);
        elevator.SetValue(elevator13, 12);
        elevator.SetValue(elevator14, 13);
        elevator.SetValue(elevator15, 14);
        guideAud.Play();
    }

    private void Update()
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
    }
}
