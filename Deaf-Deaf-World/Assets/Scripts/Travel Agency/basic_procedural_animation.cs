using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic_procedural_animation : MonoBehaviour
{
    public Transform neck;
    public Transform player;

    public bool awake;

    private float RestingX = 8.788f;
    private float lerpSpeed = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        awake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!awake)
        {
            neck.localRotation = Quaternion.Euler(55, 0, 0);
        }
        else
        {
            Vector3 ToPlayer = player.position - transform.position;
            ToPlayer.y = 0;
            float TrackingY = -Mathf.Rad2Deg * Mathf.Atan2(ToPlayer.z, ToPlayer.x);
            TrackingY = Mathf.Clamp(TrackingY, -70, 70);
            neck.localRotation = Quaternion.Slerp(neck.localRotation, Quaternion.Euler(RestingX, TrackingY, 0), lerpSpeed);
            lerpSpeed = Mathf.Lerp(lerpSpeed, 0.01f, 0.001f);
        }
    }
}
