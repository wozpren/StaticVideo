using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoHelp : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public VideoClip spp;

    public void PlayVideo(string index, Action callback)
    {
        var i = int.Parse(index) - 1;
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.clip = spp;
        videoPlayer.Play();
        float length = (float)videoPlayer.length;

        TaociManager.Intance.StartCoroutine(Video(length, callback));
        

    }

    private IEnumerator Video(float length, Action callback)
    {
        yield return new WaitForSeconds(length);
        videoPlayer.Stop();
        callback?.Invoke();
    }
}
