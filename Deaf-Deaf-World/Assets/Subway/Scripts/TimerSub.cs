using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSub : MonoBehaviour
{
    public TextMeshProUGUI text;
    float time = 61;
    public Transform endFail;

    void Start()
    {
        text.text = "Time Left: ";
    }

    void Update()
    {
        time = time - Time.deltaTime;
        text.text = "Time Left: " + (int)time;

        if (time < 0)
            endFail.gameObject.SetActive(true);
    }
}
