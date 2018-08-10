using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePlayer : Singleton<AudioSourcePlayer> {

    public AudioSource ASource;

 

	public void PlayOneShot(AudioClip clip) {
        ASource.PlayOneShot(clip);
    }

    public void PlayAtPoint (AudioClip clip, Vector3 pos) {
        AudioSource.PlayClipAtPoint(clip, pos, 1);
    }
}
