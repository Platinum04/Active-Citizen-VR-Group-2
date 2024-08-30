using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoClip[] vclips;
    public VideoPlayer vplayer;

    public int vidindex;
    public bool playing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseVid()
    {
        if (playing)
        {
            vplayer.Pause();
            playing = false;
        }
        else
        {
            vplayer.Play();
            playing = true;
        }
    
    }
    public void NextVid()
    {
        if (vidindex != vclips.Length - 1)
        {
            vidindex++;
            vplayer.clip = vclips[vidindex];
        }
        else
        {
            vidindex = 0;
            vplayer.clip = vclips[0];
        }
    }
}
