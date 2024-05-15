using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipHandler : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSound()
    {
        source.Play();
    }
    public void setAudioClip(AudioClip clip)
    {
        source.clip = clip;
    }
}
