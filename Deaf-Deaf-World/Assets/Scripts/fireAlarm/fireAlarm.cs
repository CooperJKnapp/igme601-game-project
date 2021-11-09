using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAlarm : MonoBehaviour
{

    public bool timeUp = false;
    public float currentTime = 0.0f;
    public float startingTime = 1.0f;
    public Animator anim;
    public AudioSource alarm;
    public GameObject deliver;
    public GameObject warn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUp();
        if (timeUp)
        {
            deliver.SetActive(false);
            warn.SetActive(true);
            FireAlarm();
            anim.SetBool("Flashing", true);
        }
    }
    public void FireAlarm()
    {
        if (!alarm.isPlaying)
        {
            alarm.Play();
        }
    }
    public void TimeUp()
    {
        if (currentTime > 0)
        {
            timeUp = false;
            currentTime -= Time.deltaTime;
        }
        else
        {
            timeUp = true;
        }
    }
}
