using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioController : MonoBehaviour
{
    bool isMuted = false;
    bool isPaused = false;

    void Update()
    {
        // Mute/Unmute
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;
            AudioListener.volume = isMuted ? 0f : 1f;
        }

        // Pause/Resume
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            AudioListener.pause = isPaused;
        }
    }
}
