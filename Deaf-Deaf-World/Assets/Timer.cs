using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    float time = 31;

    void Start()
    {
        text.text = "Time Left: ";
    }

    void Update()
    {
        time = time - Time.deltaTime;
        text.text = "Time Left: " + (int)time;
    }
}
