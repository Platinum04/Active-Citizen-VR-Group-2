using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    public VideoClip[] vclips;
    public VideoPlayer vplayer;

    public int vidindex;
    public bool playing;

    public Image playbuttonimg;
    public Sprite playimg;
    public Sprite pauseimg;
    // Start is called before the first frame update
    void Start()
    {
        vplayer.clip = vclips[vidindex];

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
            playbuttonimg.sprite = pauseimg;
            playing = false;
        }
        else
        {
            vplayer.Play();
            playbuttonimg.sprite = playimg;
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
    public void PrevVid()
    {
        if (vidindex != 0)
        {
            vidindex--;
            vplayer.clip = vclips[vidindex];
        }
        else
        {
            vidindex = vclips.Length - 1;
            vplayer.clip = vclips[vidindex];
        }
    }
}
