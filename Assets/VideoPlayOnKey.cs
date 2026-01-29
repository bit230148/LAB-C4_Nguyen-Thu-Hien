using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayOnKey : MonoBehaviour
{
    private VideoPlayer vp;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            vp.Play();
        }
    }
}
