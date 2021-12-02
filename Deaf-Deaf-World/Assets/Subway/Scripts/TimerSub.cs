using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSub : MonoBehaviour
{
    public TextMeshProUGUI text;
    float time = 61;
    public Transform endFail;

    private bool doTime =false;

    void Start()
    {
        text.text = "TIME LEFT : ";
    }

    void Update()
    {
        if (doTime)
        {
            time = time - Time.deltaTime;
            text.text = "TIME LEFT : " + (int)time;

        }
        if (time < 0)
        {
            endFail.gameObject.SetActive(true);
            doTime = false;
        }
    }

    public void SetTime()
    {
        doTime = true;
    }

    public void StopTime()
    {
        doTime = false;

    }
}
