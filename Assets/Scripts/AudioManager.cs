using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> clipList;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
    }
    private AudioClip GetRandomClip()
    {
        return clipList[Random.Range(0, clipList.Count)];
    }
    private void Update()
    {
        if(!source.isPlaying)
        {
            source.clip = GetRandomClip();
            source.Play();
        }
    }
}
